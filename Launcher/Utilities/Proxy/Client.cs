using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Launcher.Utilities.Proxy
{
    [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
    public class Client
    {
        /// <summary>
        /// The maximum amount of data to receive in a single packet.
        /// </summary>
        private const int MaxBufferSize = 4096;

        /// <summary>
        /// Internal client state to prevent multiple stop calls.
        /// (Helps reduce the number of unneeded exceptions.)
        /// </summary>
        private bool _isRunning;
        private bool _isAwaitingAttack = false;

        /// <summary>
        /// Encryption keys
        /// </summary>
        private byte[] _serverSendKey = new byte[8];
        private byte[] _serverReceiveKey = new byte[8];
        private byte[] _clientSendKey = new byte[8];
        private byte[] _clientReceiveKey = new byte[8];
        private bool _hasEncryptionKeys;
        private List<byte[]> _clientReceiveKey_attackOnly = new List<byte[]>();

        /// <summary>
        /// Client variables.
        /// </summary>
        private Socket _clientSocket;
        private readonly byte[] _clientBuffer;
        private readonly List<byte> _clientBackklog;

        /// <summary>
        /// ProxyServer variables.
        /// </summary>
        private Socket _serverSocket;
        private readonly byte[] _serverBuffer;
        private readonly List<byte> _serverBacklog;

        private byte[] _lastAttackPacket = null;
        private byte[] _charId = new byte[4];

        private List<string> _packetLog = new List<string>();
        private List<string> _doublePacketLog = new List<string>();

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        static bool ByteArrayCompare(byte[] b1, byte[] b2)
        {
            if (b1 == null || b2 == null)
                return false;

            // Validate buffers are the same length.
            // This also ensures that the count does not exceed the length of either buffer.  
            return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="sockClient"></param>
        public Client(Socket sockClient)
        {
            // Setup class defaults..
            this._clientSocket = sockClient;
            this._clientBuffer = new byte[MaxBufferSize];
            this._clientBackklog = new List<byte>();

            this._serverSocket = null;
            this._serverBuffer = new byte[MaxBufferSize];
            this._serverBacklog = new List<byte>();
        }

        /// <summary>
        /// Starts our proxy client.
        /// </summary>
        /// <param name="remoteTarget"></param>
        /// <param name="remotePort"></param>
        /// <returns></returns>
        public bool Start(string remoteTarget = "127.0.0.1", int remotePort = 2000)
        {
            // Stop this client if it was already started before..
            if (this._isRunning)
                this.Stop();

            this._isRunning = true;

            // Attempt to parse the given remote target.
            // This allows an IP address or domain to be given.
            // Ex:
            //      127.0.0.1
            //      derp.no-ip.org

            IPAddress ipAddress;

            try
            {
                ipAddress = IPAddress.Parse(remoteTarget);
            }
            catch
            {
                try
                {
                    ipAddress = Dns.GetHostEntry(remoteTarget).AddressList[0];
                }
                catch
                {
                    throw new SocketException((int)SocketError.HostNotFound);
                }
            }

            try
            {
                // Connect to the target machine on a new socket..
                this._serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this._serverSocket.NoDelay = true; // disable nagle

                this._serverSocket.BeginConnect(new IPEndPoint(ipAddress, remotePort),
                    result =>
                    {
                        // Ensure the connection was valid..
                        if (result == null || !result.IsCompleted || !(result.AsyncState is Socket))
                            return;

                        // Obtain our server instance.
                        var serverSocket = (Socket)result.AsyncState;

                        // Stop processing if the server has told us to stop..
                        if (!this._isRunning)
                            return;

                        // Complete the async connection request..
                        serverSocket.EndConnect(result);

                        // Start monitoring for packets..
                        this._clientSocket.ReceiveBufferSize = MaxBufferSize;
                        serverSocket.ReceiveBufferSize = MaxBufferSize;
                        this.Server_BeginReceive();
                        this.Client_BeginReceive();
                    }, this._serverSocket);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Stops this client object.
        /// </summary>
        public void Stop()
        {
            if (this._isRunning == false)
                return;

            // Cleanup the client socket..
            if (this._clientSocket != null)
                this._clientSocket.Close();
            this._clientSocket = null;

            // Cleanup the server socket..
            if (this._serverSocket != null)
                this._serverSocket.Close();
            this._serverSocket = null;

            this._isRunning = false;

            var filename = "Log_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt";
            var deskopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.StreamWriter file = new System.IO.StreamWriter(deskopPath + "\\" + filename);
            foreach(var packet in this._packetLog)
            {
                file.WriteLine(packet);
            }

            foreach (var packet in this._doublePacketLog)
            {
                file.WriteLine(packet);
            }

            file.Close();
        }

        /// <summary>
        /// Begins an async event to receive incoming data.
        /// </summary>
        private void Client_BeginReceive()
        {
            // Prevent invalid call..
            if (!this._isRunning)
                return;

            try
            {
                this._clientSocket.BeginReceive(this._clientBuffer, 0, MaxBufferSize, SocketFlags.None,
                    OnClientReceiveData, this._clientSocket);
            }
            catch (SocketException)
            {
                this.Stop();
            }
            catch (Exception)
            {
                this.Stop();
            }
        }

        /// <summary>
        /// Begins an async event to receive incoming data. 
        /// </summary>
        private void Server_BeginReceive()
        {
            // Prevent invalid call..
            if (!this._isRunning)
                return;

            try
            {
                this._serverSocket.BeginReceive(this._serverBuffer, 0, MaxBufferSize, SocketFlags.None,
                    OnServerReceiveData, this._serverSocket);
            }
            catch (SocketException)
            {
                this.Stop();
            }
            catch (Exception)
            {
                this.Stop();
            }
        }

        /// <summary> 
        /// Completes an async event to receive data. 
        /// </summary> 
        /// <param name="result"></param> 
        private void OnClientReceiveData(IAsyncResult result)
        {
            // Prevent invalid calls to this function.. 
            if (!this._isRunning || result.IsCompleted == false || !(result.AsyncState is Socket))
            {
                this.Stop();
                return;
            }

            var client = (Socket)result.AsyncState;

            // Attempt to end the async call.. 
            int nRecvCount;
            try
            {
                nRecvCount = client.EndReceive(result);
                if (nRecvCount == 0)
                {
                    this.Stop();
                    return;
                }
            }
            catch
            {
                this.Stop();
                return;
            }

            // Copy the obtained data into the backlog.. 
            var btRecvData = new byte[nRecvCount];
            Array.Copy(this._clientBuffer, 0, btRecvData, 0, nRecvCount);
            this._clientBackklog.AddRange(btRecvData);

            // Process all the packets in the backlog.. 
            for (;;)
            {
                if (this._clientBackklog.Count < 4)
                    break;

                var nPacketSize = BitConverter.ToInt16(this._clientBackklog.ToArray(), 0);

                if (this._clientBackklog.Count < nPacketSize)
                    break;

                var btPacket = new byte[nPacketSize];
                Array.Copy(this._clientBackklog.ToArray(), 0, btPacket, 0, nPacketSize);
                this._clientBackklog.RemoveRange(0, nPacketSize);

                if (!this._hasEncryptionKeys)
                {
                    this.SendToServer(btPacket);
                    break;
                }

                // Decrypt packet
                var decryptedPacket = Encryption.Decrypt(btPacket, this._clientReceiveKey);

                // Get new key seed and update key
                var newSeed = new byte[4];
                Array.Copy(decryptedPacket, 0, newSeed, 0, 4);

                this._clientReceiveKey = Encryption.UpdateKey(this._clientReceiveKey, newSeed);

                // length of the C_Attack packet should be 12
                if (decryptedPacket[0] == OpCodes.C_Attack && decryptedPacket.Length == 12 &&
                    this.IsSameMob(decryptedPacket, OpCodes.C_Attack))
                {
                    this._isAwaitingAttack = true;

                    this._clientReceiveKey_attackOnly.Add(this._clientReceiveKey);

                    this.SendToClient(this._lastAttackPacket, true);
                }

                this.SendToServer(decryptedPacket, true);
            }

            // Begin listening for next packet.. 
            this.Client_BeginReceive();
        }

        /// <summary> 
        /// Completes an async event to receive data. 
        /// </summary> 
        /// <param name="result"></param> 
        private void OnServerReceiveData(IAsyncResult result)
        {
            // Prevent invalid calls to this function.. 
            if (!this._isRunning || result.IsCompleted == false || !(result.AsyncState is Socket))
            {
                this.Stop();
                return;
            }

            var server = (Socket)result.AsyncState;

            // Attempt to end the async call.. 
            int nRecvCount;
            try
            {
                nRecvCount = server.EndReceive(result);
                if (nRecvCount == 0)
                {
                    this.Stop();
                    return;
                }
            }
            catch
            {
                this.Stop(); return;
            }

            // Copy the obtained data into the backlog.. 
            var btRecvData = new byte[nRecvCount];
            Array.Copy(this._serverBuffer, 0, btRecvData, 0, nRecvCount);
            this._serverBacklog.AddRange(btRecvData);

            for (;;)
            {
                if (this._serverBacklog.Count < 4)
                    break;

                var nPacketSize = BitConverter.ToInt16(this._serverBacklog.ToArray(), 0);
                if (this._serverBacklog.Count < nPacketSize)
                    break;

                var btPacket = new byte[nPacketSize];
                Array.Copy(this._serverBacklog.ToArray(), 0, btPacket, 0, nPacketSize);
                this._serverBacklog.RemoveRange(0, nPacketSize);

                if (btPacket[2] == 125 && !this._hasEncryptionKeys)
                {
                    var seed = new byte[4];
                    Array.Copy(btPacket, 3, seed, 0, 4);

                    this._serverSendKey = Encryption.InitKeys(BitConverter.ToUInt32(seed, 0));
                    this._serverReceiveKey = Encryption.InitKeys(BitConverter.ToUInt32(seed, 0));
                    this._clientSendKey = Encryption.InitKeys(BitConverter.ToUInt32(seed, 0));
                    this._clientReceiveKey = Encryption.InitKeys(BitConverter.ToUInt32(seed, 0));

                    this._hasEncryptionKeys = true;

                    // Initial packet to the client
                    this.SendToClient(btPacket);
                    break;
                }

                // Decrypt packet
                var decryptedPacket = Encryption.Decrypt(btPacket, this._serverReceiveKey);

                // Get new key seed and update key
                var newSeed = new byte[4];
                Array.Copy(decryptedPacket, 0, newSeed, 0, 4);

                _serverReceiveKey = Encryption.UpdateKey(this._serverReceiveKey, newSeed);

                while (this._packetLog.Count > 1000)
                {
                    this._packetLog.RemoveAt(0);
                }

                // ignore the AttackPacket coming from the server since we are handling it ourselves.
                // but allow it through if it is the first attack on a new target
                // however, stop it if for some reason we are still waiting for the attack on the last target to hit the client
                if (!this.IsOwnAttackPacket(decryptedPacket, this._charId)
                    || (!this.IsSameMob(decryptedPacket, OpCodes.S_AttackPacket) && !this._isAwaitingAttack))
                {
                    this._packetLog.Add(DateTime.Now.ToShortTimeString() + ": Sent server packet to client");
                    this._packetLog.Add(string.Join(",", decryptedPacket.Select(b => b.ToString()).ToArray()));
                    this.SendToClient(decryptedPacket, true);
                }  

                // if it is an S_AttackPacket and the ID is the current character
                // and we aren't already expecting a packet to be sent to the client
                if (this.IsOwnAttackPacket(decryptedPacket, this._charId))
                {
                    this._packetLog.Add(DateTime.Now.ToShortTimeString() + ": "
                        + string.Join(",", decryptedPacket.Select(b => b.ToString()).ToArray()));

                    // if we are awaiting an attack back, do not update the last attack packet, we can get it on the next swing
                    if (this._lastAttackPacket == null || (!ByteArrayCompare(decryptedPacket, this._lastAttackPacket) && !this._isAwaitingAttack))
                    {
                        this._packetLog.Add(DateTime.Now.ToShortTimeString() + ": Queued last attack packet");
                        this._lastAttackPacket = decryptedPacket;
                    }   
                }
                else if (decryptedPacket[0] == OpCodes.S_OwnCharStatus)
                {
                    for (var i = 0; i < 4; i++) // gets the users id from the char status
                        this._charId[i] = decryptedPacket[i + 1];
                }
            }
            // Begin listening for next packet.. 
            this.Server_BeginReceive();
        }
        
        /// <summary>
        /// Sends the given packet data to the client socket.
        /// </summary>
        /// <param name="btPacket"></param>
        /// <param name="encrypt"></param>
        public void SendToClient(byte[] btPacket, bool encrypt = false)
        {
            if (!this._isRunning)
                return;

            // if we received an attack packet but weren't waiting on one, then just return
            if(!this._isAwaitingAttack && ByteArrayCompare(btPacket, this._lastAttackPacket))
                return;

            try
            {
                var packets = new List<byte[]>();

                if (this._isAwaitingAttack)
                {
                    // only add it if it isn't the current packet being sent
                    if(!ByteArrayCompare(btPacket, this._lastAttackPacket)) {
                        packets.Add(this._lastAttackPacket);
                    }
                    
                    this._isAwaitingAttack = false;
                }   

                packets.Add(btPacket);

                for(var i = 0; i < packets.Count; i++)
                {
                    if (encrypt || (i == 0 && packets.Count == 2))
                    {
                        // Get new seed for key
                        var newSeed = new byte[4];
                        Array.Copy(packets[i], 0, newSeed, 0, 4);

                        // it's an attack packet and we haven't waited for a response from the server
                        if(i == 0 && packets.Count == 2)
                        {
                            this._doublePacketLog.Add("Double packet received key had: " + this._clientReceiveKey_attackOnly.Count + " entries");
                            this._doublePacketLog.Add("Received at: " + DateTime.Now.ToShortTimeString());
                            // Encrypt modified packet

                            for (var j = this._clientReceiveKey_attackOnly.Count - 1; i > 0; i--)
                            {
                                this._doublePacketLog.Add("Key Used: " + 
                                    string.Join(",", this._clientReceiveKey_attackOnly[j].Select(b => b.ToString()).ToArray()));

                                this._doublePacketLog.Add("Packet: " +
                                    packets[i].Select(b => b.ToString()).ToArray());

                                btPacket = Encryption.Encrypt(packets[i], this._clientReceiveKey_attackOnly[j]);
                                this._clientReceiveKey_attackOnly.Remove(btPacket);

                                this._clientSocket.BeginSend(btPacket, 0, btPacket.Length, SocketFlags.None,
                                x =>
                                {
                                    if (!x.IsCompleted || !(x.AsyncState is Socket))
                                    {
                                        this.Stop();
                                        return;
                                    }

                                    ((Socket)x.AsyncState).EndSend(x);
                                }, this._clientSocket);
                            }

                            return;
                        }
                        else
                        {
                            // Encrypt modified packet
                            btPacket = Encryption.Encrypt(packets[i], this._clientSendKey);

                            // Update key for next packet
                            this._clientSendKey = Encryption.UpdateKey(this._clientSendKey, newSeed);
                        }
                    }

                    this._clientSocket.BeginSend(btPacket, 0, btPacket.Length, SocketFlags.None,
                        x =>
                        {
                            if (!x.IsCompleted || !(x.AsyncState is Socket))
                            {
                                this.Stop();
                                return;
                            }

                            ((Socket)x.AsyncState).EndSend(x);
                        }, this._clientSocket);
                }
            }
            catch (Exception)
            {
                this.Stop();
            }
        }

        /// <summary>
        /// Sends the given packet data to the server socket.
        /// </summary>
        /// <param name="btPacket"></param>
        /// <param name="encrypt"></param>
        public void SendToServer(byte[] btPacket, bool encrypt = false)
        {
            if (!this._isRunning)
                return;

            try
            {
                if(encrypt)
                {
                    // Get new seed for key
                    var newSeed = new byte[4];
                    Array.Copy(btPacket, 0, newSeed, 0, 4);

                    // Encrypt modified packet
                    btPacket = Encryption.Encrypt(btPacket, _serverSendKey);

                    // Update key for next packet
                    this._serverSendKey = Encryption.UpdateKey(this._serverSendKey, newSeed);
                }

                this._serverSocket.BeginSend(btPacket, 0, btPacket.Length, SocketFlags.None,
                    x =>
                    {
                        if (!x.IsCompleted || !(x.AsyncState is Socket))
                        {
                            this.Stop();
                            return;
                        }

                        ((Socket)x.AsyncState).EndSend(x);
                    }, this._serverSocket);
            }
            catch (Exception)
            {
                this.Stop();
            }
        }

        /// <summary>
        /// Gets the base client socket.
        /// </summary>
        public Socket ClientSocket
        {
            get
            {
                if (this._isRunning && this._clientSocket != null)
                    return this._clientSocket;

                return null;
            }
        }

        /// <summary>
        /// Gets the base server socket.
        /// </summary>
        public Socket ServerSocket
        {
            get
            {
                if (this._isRunning && this._serverSocket != null)
                    return this._serverSocket;

                return null;
            }
        }

        private bool IsSameMob(byte[] packet, int opcode)
        {
            if (this._lastAttackPacket == null)
                return false;
               
            if(opcode == OpCodes.C_Attack)
                return packet[0] == OpCodes.C_Attack && packet[1] == this._lastAttackPacket[6];
                
            if(opcode == OpCodes.S_AttackPacket)
                return packet[0] == OpCodes.S_AttackPacket && packet[6] == this._lastAttackPacket[6];

            return false;
        }

        private bool IsOwnAttackPacket(byte[] packet, byte[] charId)
        {
            // the S_AttackPacket length is 20 -- this is required so we don't crap out other, non-melee attack types
            return packet.Length == 20 && packet[0] == OpCodes.S_AttackPacket
                    && packet[2] == this._charId[0] && packet[3] == this._charId[1]
                    && packet[4] == this._charId[2] && packet[5] == this._charId[3];
        }

        private static List<T> ToListOf<T>(byte[] array, Func<byte[], int, T> bitConverter)
        {
            var size = Marshal.SizeOf(typeof(T));
            return Enumerable.Range(0, array.Length / size)
                             .Select(i => bitConverter(array, i * size))
                             .ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Utilities.Proxy
{
    [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
    public class Client
    {
        private readonly DateTime _epochDate;
        /// <summary>
        /// The maximum amount of data to receive in a single packet.
        /// </summary>
        private const int MaxBufferSize = 4096;

        /// <summary>
        /// Internal client state to prevent multiple stop calls.
        /// (Helps reduce the number of unneeded exceptions.)
        /// </summary>
        private bool _isRunning;

        /// <summary>
        /// Encryption keys
        /// </summary>
        private byte[] _serverSendKey = new byte[8];
        private byte[] _serverReceiveKey = new byte[8];
        private byte[] _clientSendKey = new byte[8];
        private byte[] _clientReceiveKey = new byte[8];
        private bool _hasEncryptionKeys;

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

        public int LastPacketSent { get; private set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="sockClient"></param>
        public Client(Socket sockClient)
        {
            // Setup class defaults..
            this._clientSocket = sockClient;
            this._clientSocket.NoDelay = true;
            this._clientBuffer = new byte[MaxBufferSize];
            this._clientBackklog = new List<byte>();

            this._serverSocket = null;
            this._serverBuffer = new byte[MaxBufferSize];
            this._serverBacklog = new List<byte>();

            this._epochDate = new DateTime(1970, 1, 1);
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

            // initialize it to 5 minutes in the future
            this.LastPacketSent = (int)(DateTime.UtcNow - this._epochDate).TotalSeconds + 300;

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
                this._serverSocket.NoDelay = true;

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

            this.LastPacketSent = (int)(DateTime.UtcNow - this._epochDate).TotalSeconds;

            // Process all the packets in the backlog.. 
            for (; ; )
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
                _clientReceiveKey = Encryption.UpdateKey(_clientReceiveKey, newSeed);

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

            for (; ; )
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
                var decryptedPacket = Encryption.Decrypt(btPacket, _serverReceiveKey);

                // Get new key seed and update key
                var newSeed = new byte[4];
                Array.Copy(decryptedPacket, 0, newSeed, 0, 4);
                _serverReceiveKey = Encryption.UpdateKey(_serverReceiveKey, newSeed);

                this.SendToClient(decryptedPacket, true);
            }
            // Begin listening for next packet.. 
            this.Server_BeginReceive();
        }

        /// <summary>
        /// Sends the given packet data to the client socket.
        /// </summary>
        /// <param name="btPacket"></param>
        public void SendToClient(byte[] btPacket)
        {
            if (!this._isRunning)
                return;

            try
            {
                this._clientSocket.BeginSend(btPacket, 0, btPacket.Length, SocketFlags.None,
                    x =>
                    {
                        if (!x.IsCompleted || !(x.AsyncState is Socket))
                        {
                            this.Stop();
                            return;
                        }

                        ((Socket) x.AsyncState).EndSend(x);
                    }, this._clientSocket);
            }
            catch (Exception)
            {
                this.Stop();
                
            }
        }

        /// <summary>
        /// Sends the given packet data to the client socket.
        /// </summary>
        /// <param name="btPacket"></param>
        /// <param name="encrypt"></param>
        public void SendToClient(byte[] btPacket, bool encrypt)
        {
            if (!this._isRunning)
                return;

            try
            {
                // Get new seed for key
                var newSeed = new byte[4];
                Array.Copy(btPacket, 0, newSeed, 0, 4);

                // Encrypt modified packet
                var encryptedPacket = Encryption.Encrypt(btPacket, _clientSendKey);

                // Update key for next packet
                this._clientSendKey = Encryption.UpdateKey(this._clientSendKey, newSeed);

                this._clientSocket.BeginSend(encryptedPacket, 0, encryptedPacket.Length, SocketFlags.None,
                    x =>
                    {
                        if (!x.IsCompleted || !(x.AsyncState is Socket))
                        {
                            this.Stop();
                            return;
                        }

                        ((Socket) x.AsyncState).EndSend(x);
                    }, this._clientSocket);
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
        public void SendToServer(byte[] btPacket)
        {
            if (!this._isRunning)
                return;

            try
            {
                this._serverSocket.BeginSend(btPacket, 0, btPacket.Length, SocketFlags.None,
                    x =>
                    {
                        if (!x.IsCompleted || !(x.AsyncState is Socket))
                        {
                            this.Stop();
                            return;
                        }

                        ((Socket) x.AsyncState).EndSend(x);
                    }, this._serverSocket);
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
        public void SendToServer(byte[] btPacket, bool encrypt)
        {
            if (!this._isRunning)
                return;

            try
            {
                // Get new seed for key
                var newSeed = new byte[4];
                Array.Copy(btPacket, 0, newSeed, 0, 4);

                // Encrypt modified packet
                var encryptedPacket = Encryption.Encrypt(btPacket, _serverSendKey);

                // Update key for next packet
                this._serverSendKey = Encryption.UpdateKey(this._serverSendKey, newSeed);

                this._serverSocket.BeginSend(encryptedPacket, 0, encryptedPacket.Length, SocketFlags.None,
                    x =>
                    {
                        if (!x.IsCompleted || !(x.AsyncState is Socket))
                        {
                            this.Stop();
                            return;
                        }

                        ((Socket) x.AsyncState).EndSend(x);
                    }, this._serverSocket);
            }
            catch (Exception)
            {
                this.Stop();
            }
        }

        public void SendKeepAlive()
        {
            this.LastPacketSent = (int)(DateTime.UtcNow - this._epochDate).TotalSeconds;
            byte[] keepAlivePacket = { (byte)OpCodes.ClientOpCodes.KeepAlive, 0x00, 0x04, 0x00 };

            this.SendToServer(keepAlivePacket, true);
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
    }
}

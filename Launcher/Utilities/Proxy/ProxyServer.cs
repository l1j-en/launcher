using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Utilities.Proxy
{
    [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
    public class ProxyServer
    {
        private TcpListener _serverListener;
        private Client _clientListener;

        public string LocalAddress { get; set; }
        public int LocalPort { get; set; }

        public string RemoteAddress { get; set; }
        public int RemotePort { get; set; }

        public ProxyServer()
        {
            this.LocalAddress = IPAddress.Loopback.ToString();
            this.LocalPort = 2000;
            this.RemoteAddress = IPAddress.Loopback.ToString();
            this.RemotePort = 2000;
        }

        public int CheckLastSent()
        {
            if (this._clientListener == null)
                return -1;

            return this._clientListener.LastPacketSent;
        }

        public void SendKeepAlive()
        {
            this._clientListener.SendKeepAlive();
        }
        /// <summary>
        /// Starts our listen server to accept incoming connections.
        /// </summary>
        /// <returns>True if successful, else false.</returns>
        public bool Start()
        {
            try
            {
                // Cleanup any previous objects..
                this.Stop();

                // Create the new TcpListener..
                this._serverListener = new TcpListener(IPAddress.Parse(this.LocalAddress), this.LocalPort);
                this._serverListener.Start();

                // Setup the async handler when a client connects..
                this._serverListener.BeginAcceptTcpClient(OnAcceptTcpClient, this._serverListener);
                return true;
            }
            catch (Exception)
            {
                this.Stop();
                return false;
            }
        }

        /// <summary>
        /// Stops the local listening server if it is started.
        /// </summary>
        public void Stop()
        {
            // Cleanup the client object..
            if (this._clientListener != null)
                this._clientListener.Stop();
            this._clientListener = null;

            // Cleanup the server object..
            if (this._serverListener != null)
                this._serverListener.Stop();
            this._serverListener = null;
        }

        /// <summary>
        /// Async callback handler that accepts incoming TcpClient connections.
        /// NOTE:
        ///     It is important that you use the results server object to
        ///     prevent threading issues and object disposed errors!
        /// </summary>
        /// <param name="result"></param>
        private void OnAcceptTcpClient(IAsyncResult result)
        {
            // Ensure this connection is complete and valid..
            if (!result.IsCompleted || !(result.AsyncState is TcpListener))
            {
                this.Stop();
                return;
            }

            // Obtain our server instance.
            var tcpServer = (TcpListener)result.AsyncState;

            if (tcpServer == null || tcpServer.Server == null || !tcpServer.Server.IsBound)
            {
                this.Stop();
                return;
            }

            // End the async connection request..
            var tcpClient = tcpServer.EndAcceptTcpClient(result);

            // Kill the previous client that was connected (if any)..
            if (this._clientListener != null)
                this._clientListener.Stop();

            // Prepare the client and start the proxying..
            this._clientListener = new Client(tcpClient.Client);
            this._clientListener.Start(this.RemoteAddress, this.RemotePort);

            // Begin listening for the next client..
            tcpServer.BeginAcceptTcpClient(OnAcceptTcpClient, tcpServer);
        } //end OnAcceptTcpClient
    }
}

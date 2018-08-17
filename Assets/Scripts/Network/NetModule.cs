using LiteNetLib;
using NoMansBlocks.Core;
using NoMansBlocks.Logging;
using NoMansBlocks.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network {
    /// <summary>
    /// Engine module for running the network connection. This maintains
    /// the connection with the host, or multiple clients if running as
    /// the host.
    /// </summary>
    public sealed partial class NetModule : Module {
        #region Properties
        /// <summary>
        /// If this network module is the host of
        /// the lobby.
        /// </summary>
        public bool IsServer { get; }

        /// <summary>
        /// The port number to use. This is only
        /// considered if the module is being ran
        /// as a server.
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// The maximum number of connectons allowed to be
        /// connected at any time.
        /// </summary>
        public int MaxConnections { get; }

        /// <summary>
        /// Handles firing off alerts when messages come
        /// in across the network.
        /// </summary>
        public INetMessageListener MessageListener {
            get {
                return netListener as INetMessageListener;
            }
        }

        /// <summary>
        /// The connections currently active with the network.
        /// </summary>
        public List<INetConnection> Connections { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The NetManager for interfacing directly with the network.
        /// </summary>
        private readonly NetManager netManager;

        /// <summary>
        /// The listener that fires off message recieved 
        /// events.
        /// </summary>
        private readonly NetMessageListener netListener;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the net module. The module
        /// needs to know whether to run in client, or host mode.
        /// </summary>
        /// <param name="isServer">Is this a server instance?</param>
        /// <param name="maxConnections">The maximum number of connections permitted.</param>
        /// <param name="port">The port number to use.</param>
        public NetModule(bool isServer, int maxConnections = 1, int port = 0) {
            IsServer       = IsServer;
            Port           = IsServer ? port : 0;
            MaxConnections = IsServer ? MaxConnections : 1;

            netListener = new NetMessageListener();
            netManager  = new NetManager(netListener, "NoMansBlocks");
        }
        #endregion

        #region Module Events
        /// <summary>
        /// Prepare the netmodule for use.
        /// </summary>
        public override void OnInit() {
            netManager.Start(Port);
        }
        #endregion

        #region Publics
        /// <summary>
        /// Connect to a new server.
        /// </summary>
        /// <param name="endPoint">The server's ip address.</param>
        public void Connect(NetEndPoint endPoint) {
            if (!netManager.IsRunning) {
                netManager.Start(Port);
            }

            if (!IsServer && netManager.PeersCount == 0) {
                netManager.Connect(endPoint);
            }
        }

        /// <summary>
        /// Disconnect every connection currently active with
        /// the netmodule.
        /// </summary>
        public void Disconnect() {
            netManager.Stop();
        }

        /// <summary>
        /// Send a message out to every active connection.
        /// </summary>
        /// <param name="message">The message to send to everyone.</param>
        /// <param name="options">How to send the message.</param>
        public void SendMessage(NetMessage message, SendOptions options) {
            byte[] payLoad = message.Serialize();
            netManager.SendToAll(payLoad, options);
        }

        /// <summary>
        /// Send a message out to a specific active connection.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="connection">The receiever.</param>
        /// <param name="options">How to send the message.</param>
        public void SendMessage(NetMessage message, INetConnection connection, SendOptions options) {

        }
        #endregion
    }
}

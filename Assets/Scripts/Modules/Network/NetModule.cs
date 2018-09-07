using LiteNetLib;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Logging;
using NoMansBlocks.Modules.Config;
using NoMansBlocks.Modules.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network {
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
        public bool IsServer { get { return Engine.Type == GameEngineType.Server; } }

        /// <summary>
        /// Handles firing off alerts when messages come
        /// in across the network.
        /// </summary>
        public INetMessageListener MessageListener {
            get {
                return messageListener as INetMessageListener;
            }
        }

        /// <summary>
        /// The manager for the connections with the network.
        /// </summary>
        public NetConnectionManager ConnectionManager { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The NetManager for interfacing directly with the network.
        /// </summary>
        private NetManager netManager;

        /// <summary>
        /// The listener that fires off message recieved 
        /// events.
        /// </summary>
        private NetMessageListener messageListener;

        /// <summary>
        /// The configurations to run under.
        /// </summary>
        private NetworkConfig config;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the net module. The module
        /// needs to know whether to run in client, or host mode.
        /// </summary>
        /// <paramref name="engine">The engine that owns the module.</paramref>
        public NetModule(GameEngine engine) : base(engine) {
            messageListener = new NetMessageListener();
            netManager = new NetManager(messageListener, "NoMansBlocks");
        }
        #endregion

        #region Module Events
        /// <summary>
        /// Prepare the netmodule for use.
        /// </summary>
        public override void OnStart() {
            //Pull in the network configs
            config = GetModule<ConfigModule>().GetConfig<NetworkConfig>();

            //Set up the connection manager and start it.
            ConnectionManager = new NetConnectionManager(messageListener, config.ConnectionCapacity);
            netManager.Start(config.Port);
        }
        #endregion

        #region Publics
        /// <summary>
        /// Connect to a new server.
        /// </summary>
        /// <param name="endPoint">The server's ip address.</param>
        public void Connect(NetEndPoint endPoint) {
            if (!netManager.IsRunning) {
                netManager.Start(config.Port);
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
        public void SendMessage(NetUnconnectedMessage message, SendOptions options) {
            byte[] payLoad = message.Serialize();

        }

        /// <summary>
        /// Send a message out to a specific active connection.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="connection">The receiever.</param>
        /// <param name="options">How to send the message.</param>
        public void SendMessage(NetUnconnectedMessage message, INetConnection connection, SendOptions options) {
            byte[] payLoad = message.Serialize();

        }
        #endregion
    }
}

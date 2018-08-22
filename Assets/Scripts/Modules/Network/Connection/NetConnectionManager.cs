using LiteNetLib;
using NoMansBlocks.Logging;
using NoMansBlocks.Modules.Logging;
using NoMansBlocks.Modules.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network {
    /// <summary>
    /// Handles maintaining connections with
    /// other network users.
    /// </summary>
    public sealed partial class NetConnectionManager {
        #region Properties
        /// <summary>
        /// The number of currently active connections.
        /// </summary>
        public int ConnectionCount { get { return connections.Count; } }

        /// <summary>
        /// The maximum number of connections the manager allows for.
        /// </summary>
        public int MaxConnections { get; }
        #endregion

        #region Members
        /// <summary>
        /// The connections currently active with the manager.
        /// </summary>
        private List<NetConnection> connections;

        /// <summary>
        /// Reference back to the message listener.
        /// </summary>
        private INetMessageListener messageListener;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new net connection manager. This will handle
        /// allowing, or rejecting incoming connections along with
        /// sending out info.
        /// </summary>
        /// <param name="messageListener">The incoming message listener.</param>
        /// <param name="maxConnections">The maximum number of connections allowed.</param>
        public NetConnectionManager(INetMessageListener messageListener, int maxConnections) {
            connections    = new List<NetConnection>();
            MaxConnections = maxConnections;

            messageListener.OnConnectionMessage += OnConnectionMessage;
        }

        /// <summary>
        /// Called when disposing of. This prevents memory leaks.
        /// </summary>
        ~NetConnectionManager() {
            messageListener.OnConnectionMessage -= OnConnectionMessage;
        }
        #endregion

        #region Events
        /// <summary>
        /// Listen for incoming connection messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConnectionMessage(object sender, NetConnectionMessageArgs e) {
            switch (e.Message.Type) {
                case NetConnectionMessageType.Request:
                    NetConnectionRequestMessage reqMsg = e.Message as NetConnectionRequestMessage;

                    //TODO: Add ban system here.
                    Log.Debug("New connection! {0}", reqMsg.Client.EndPoint);


                    break;

                case NetConnectionMessageType.Disconnected:

                    break;
            }

        }
        #endregion

        #region Publics
        /// <summary>
        /// Get all of the currently active connections.
        /// </summary>
        /// <returns>The list of every connection.</returns>
        public List<INetConnection> GetConnections() {
            List<INetConnection> conns = new List<INetConnection>();
            connections?.ForEach(c => conns.Add(c as INetConnection));

            return conns;
        }

        /// <summary>
        /// Get a connection by it's unique id.
        /// </summary>
        /// <param name="id">The connection id to look for.</param>
        /// <returns>The conenction with the matching id (if any).</returns>
        public INetConnection GetConnectionById(byte id) {
            return connections.Find(c => c.ConnectionId == id) as INetConnection;
        }
        #endregion
    }
}

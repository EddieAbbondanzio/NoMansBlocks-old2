using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// Message to indicate that a client has disconnected.
    /// </summary>
    public class NetDisconnectedMessage : NetConnectionMessage {
        #region Properties
        /// <summary>
        /// Indicator of the messages general purpose.
        /// </summary>
        public override NetMessageCategory Category => NetMessageCategory.Connection;

        /// <summary>
        /// Indicator of the messages actual intent.
        /// </summary>
        public override NetConnectionMessageType Type => NetConnectionMessageType.Disconnected;

        /// <summary>
        /// The client that wants to join.
        /// </summary>
        public NetPeer Client { get; }

        /// <summary>
        /// Why the client disconnected.
        /// </summary>
        public DisconnectInfo Info { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new incoming net disconnection message.
        /// </summary>
        /// <param name="client">The client who disconnected.</param>
        /// <param name="info">Why they disconnected</param>
        public NetDisconnectedMessage(NetPeer client, DisconnectInfo info) : base(client.EndPoint) {
            Client = client;
            Info = info;
        }
        #endregion
    }
}

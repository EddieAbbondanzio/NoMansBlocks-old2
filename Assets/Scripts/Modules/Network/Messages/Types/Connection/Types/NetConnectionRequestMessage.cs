using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Message to indicate that a new client wants to join
    /// the server.
    /// </summary>
    public class NetConnectionRequestMessage : NetConnectionMessage {
        #region Properties
        /// <summary>
        /// Indicator of the messages general purpose.
        /// </summary>
        public override NetMessageCategory Category => NetMessageCategory.Connection;

        /// <summary>
        /// Indicator of the messages actual intent.
        /// </summary>
        public override NetConnectionMessageType Type => NetConnectionMessageType.Request;

        /// <summary>
        /// The client that wants to join.
        /// </summary>
        public NetPeer Client { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new client connection request 
        /// for the client passed in.
        /// </summary>
        /// <param name="client">The client that wants to connect.</param>
        public NetConnectionRequestMessage(NetPeer client) : base (client.EndPoint) {
            Client = client;
        }
        #endregion
    }
}

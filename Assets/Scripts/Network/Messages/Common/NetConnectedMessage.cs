using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// Base class for messsages that come from connected
    /// connection points to pass around.
    /// </summary>
    public abstract class NetConnectedMessage : INetMessage {
        #region Properties
        /// <summary>
        /// What category the message falls under.
        /// </summary>
        public abstract NetMessageCategory Category { get; }

        /// <summary>
        /// The connection of who sent the message.
        /// </summary>
        public INetConnection SenderConnection { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// All netmessages are expected to have a sender connection
        /// if they are incoming.
        /// </summary>
        /// <param name="senderConnection">The sender's connection.</param>
        protected NetConnectedMessage(INetConnection senderConnection) {
            SenderConnection = senderConnection;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Serialize the message into a byte array that can cross
        /// the network.
        /// </summary>
        /// <returns>The message as a byte array.</returns>
        public virtual byte[] Serialize() {
            throw new NotImplementedException();
        }
        #endregion
    }
}

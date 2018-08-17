using LiteNetLib;
using NoMansBlocks.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// Base class for all messages to derive from.
    /// This provides some common functionality across
    /// all of them.
    /// </summary>
    public abstract class NetMessage : IBinarySerializable {
        #region Properties
        /// <summary>
        /// What category the message falls under.
        /// </summary>
        public abstract NetMessageCategory Category { get; }

        /// <summary>
        /// The IP address of who sent the message.
        /// </summary>
        public NetEndPoint SenderAddress { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// All netmessages are expected to have a sender address
        /// if they are incoming.
        /// </summary>
        /// <param name="senderAddress">The sender's ip.</param>
        protected NetMessage(NetEndPoint senderAddress) {
            SenderAddress = senderAddress;
        }
        #endregion

        #region Publics
        public virtual byte[] Serialize() {
            throw new NotImplementedException();
        }
        #endregion
    }
}

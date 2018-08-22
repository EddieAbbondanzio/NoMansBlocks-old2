using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Meta info messages pertain info about the network
    /// such as latency, or errors.
    /// </summary>
    public abstract class NetMetaMessage : NetUnconnectedMessage {
        #region Properties
        /// <summary>
        /// General indicator of what the message is about.
        /// </summary>
        public override NetMessageCategory Category => NetMessageCategory.Meta;

        /// <summary>
        /// The actual meta message type it is.
        /// </summary>
        public abstract NetMetaMessgeType Type { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new incoming meta message.
        /// </summary>
        /// <param name="senderAddress">The IP of who sent it.</param>
        protected NetMetaMessage(NetEndPoint senderAddress) : base(senderAddress) {
        }
        #endregion
    }
}

using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Messages for the connection category. These pertain to things such
    /// as a new client wishing to join, or an existing one leaving.
    /// </summary>
    public abstract class NetConnectionMessage : NetUnconnectedMessage {
        #region Properties
        /// <summary>
        /// Indicator of the messages general purpose.
        /// </summary>
        public override NetMessageCategory Category => NetMessageCategory.Connection;

        /// <summary>
        /// What kind of connection message it is.
        /// </summary>
        public abstract NetConnectionMessageType Type { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new connection message.
        /// </summary>
        /// <param name="senderAddress">The address of who sent it.</param>
        protected NetConnectionMessage(NetEndPoint senderAddress) : base(senderAddress) {
        }
        #endregion
    }
}

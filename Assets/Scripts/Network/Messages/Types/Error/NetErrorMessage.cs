using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// An error message indicates that well,
    /// an error occured.
    /// </summary>
    public sealed class NetErrorMessage : NetMessage {
        #region Properties
        /// <summary>
        /// Indicator of the messages general purpose.
        /// </summary>
        public override NetMessageCategory Category => NetMessageCategory.Error;

        /// <summary>
        /// The error code better explaining the error.
        /// </summary>
        public int SocketErrorCode { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new Net Error Message.
        /// </summary>
        /// <param name="senderAddress">The sender's ip address.</param>
        /// <param name="errorCode">The error code of what went wrong.</param>
        public NetErrorMessage(NetEndPoint senderAddress, int errorCode) : base(senderAddress) {
            SocketErrorCode = errorCode;
        }
        #endregion
    }
}

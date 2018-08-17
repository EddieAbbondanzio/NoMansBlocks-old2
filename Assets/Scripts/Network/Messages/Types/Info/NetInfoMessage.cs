using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// A net info message contains info about things
    /// over the network.
    /// </summary>
    public class NetInfoMessage : NetUnconnectedMessage {
        #region Properties
        /// <summary>
        /// The general purpose of the message.
        /// </summary>
        public override NetMessageCategory Category => NetMessageCategory.Info;

        /// <summary>
        /// The latency of the network connection.
        /// </summary>
        public int Latency { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new info message that came in over
        /// the network.
        /// </summary>
        /// <param name="senderAddress">The address of who it came from.</param>
        /// <param name="latency">Their latency with the server.</param>
        public NetInfoMessage(NetEndPoint senderAddress, int latency) : base(senderAddress) {
            Latency = latency;
        }
        #endregion
    }
}

using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network {
    public sealed partial class NetConnectionManager {
        /// <summary>
        /// The actual implementation of the net connection. We hide this in the network
        /// module so no one else can create them.
        /// </summary>
        private class NetConnection : INetConnection {
            #region Properties
            /// <summary>
            /// The id of the connnection.
            /// </summary>
            public byte ConnectionId { get; set; }

            /// <summary>
            /// The sender associated with this connection.
            /// </summary>
            public NetPeer Peer { get; set; }
            #endregion
        }
    }
}

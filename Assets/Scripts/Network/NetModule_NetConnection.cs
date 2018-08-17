﻿using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network {
    /// <summary>
    /// The extension of the NetModule class that implements the
    /// nested NetConnection class.
    /// </summary>
    public sealed partial class NetModule_NetConnection {
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
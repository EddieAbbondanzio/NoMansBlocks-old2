using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// Arguments to pass a net end point around for connecting
    /// to a server.
    /// </summary>
    public sealed class ConnectEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The endpoint that the user wants to connect to.
        /// </summary>
        public NetEndPoint EndPoint { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of connect arguments.
        /// </summary>
        /// <param name="endPoint">The endpoint to connect to.</param>
        public ConnectEventArgs(NetEndPoint endPoint) {
            EndPoint = endPoint;
        }
        #endregion
    }
}

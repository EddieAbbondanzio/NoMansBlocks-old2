using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network{
    /// <summary>
    /// Interface to represent a network connection. This
    /// just prevent's new ones from being created where
    /// they shouldn't be.
    /// </summary>
    public interface INetConnection {
        #region Properties
        /// <summary>
        /// The local id used to distingush the id.
        /// </summary>
        byte ConnectionId { get; }

        /// <summary>
        /// The latency of the connection.
        /// </summary>
        int Latency { get; }
        #endregion
    }
}

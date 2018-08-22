using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network{
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
        #endregion
    }
}

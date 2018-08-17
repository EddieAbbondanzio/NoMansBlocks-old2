using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// Arguments that can pass around a net info
    /// message through events.
    /// </summary>
    public sealed class NetInfoMessageArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The message being sent around.
        /// </summary>
        public NetInfoMessage Message { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new info message args that can
        /// be passed around.
        /// </summary>
        /// <param name="message">The message in question.</param>
        public NetInfoMessageArgs(NetInfoMessage message) {
            Message = message;
        }
        #endregion
    }
}

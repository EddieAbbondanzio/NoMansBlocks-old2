using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Arguments that can pass around a net connection
    /// message through events.
    /// </summary>
    public sealed class NetConnectionMessageArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The message being sent around.
        /// </summary>
        public NetConnectionMessage Message { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new info message args that can
        /// be passed around.
        /// </summary>
        /// <param name="message">The message in question.</param>
        public NetConnectionMessageArgs(NetConnectionMessage message) {
            Message = message;
        }
        #endregion
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// Arguments that can pass around a net error
    /// message through events.
    /// </summary>
    public sealed class NetErrorMessageArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The message being sent around.
        /// </summary>
        public NetErrorMessage Message { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new error message args that 
        /// can then be passed around.
        /// </summary>
        /// <param name="message">The message in question.</param>
        public NetErrorMessageArgs(NetErrorMessage message) {
            Message = message;
        }
        #endregion
    }
}

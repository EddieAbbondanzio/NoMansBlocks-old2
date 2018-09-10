using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input.Player {
    /// <summary>
    /// Arguments for passing action event data around.
    /// </summary>
    public sealed class PlayerActionEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The type of action being performed
        /// </summary>
        public PlayerActionType ActionType { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of arguments for passing around.
        /// </summary>
        /// <param name="actionType">The type of action the player is doing.</param>
        public PlayerActionEventArgs(PlayerActionType actionType) {
            ActionType = actionType;
        }
        #endregion
    }
}

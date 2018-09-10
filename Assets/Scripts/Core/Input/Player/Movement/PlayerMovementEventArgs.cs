using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input.Player {
    /// <summary>
    /// Arguments for passing around the current movement
    /// details of the player.
    /// </summary>
    public sealed class PlayerMovementEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The direction that the player is moving in.
        /// </summary>
        public PlayerMovementType MovementType { get; }

        /// <summary>
        /// If the player is running or just walking.
        /// </summary>
        public bool IsRunning { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of movement event args.
        /// </summary>
        /// <param name="movementType">The current direction being moved in.</param>
        /// <param name="isRunning">If the player is running.</param>
        public PlayerMovementEventArgs(PlayerMovementType movementType, bool isRunning = false) {
            MovementType = movementType;
            IsRunning = isRunning;
        }
        #endregion
    }
}

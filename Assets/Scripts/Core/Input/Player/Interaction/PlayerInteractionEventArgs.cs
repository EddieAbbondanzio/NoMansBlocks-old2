using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input.Player {
    /// <summary>
    /// Arguments for passing around interaction info.
    /// </summary>
    public sealed class PlayerInteractionEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The type of interaction being performed.
        /// </summary>
        public PlayerInteractionType InteractionType { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of interaction event args.
        /// </summary>
        /// <param name="interactionType">The action being performed.</param>
        public PlayerInteractionEventArgs(PlayerInteractionType interactionType) {
            InteractionType = interactionType;
        }
        #endregion
    }
}

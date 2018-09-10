using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input.Player {
    /// <summary>
    /// Controller for the standard player where they are
    /// playing in a match.
    /// </summary>
    public sealed class PlayerInputController : IInputController {
        #region Properties
        /// <summary>
        /// If the controller is enabled and listening for input.
        /// </summary>
        public bool Enabled { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired anytime the player moves in a direction such as 
        /// forward, backwards, left or right.
        /// </summary>
        public event EventHandler<PlayerMovementEventArgs> OnMove;

        /// <summary>
        /// Fired off anytime the player does something such as 
        /// fire their weapon or use a tool.
        /// </summary>
        public event EventHandler<PlayerActionEventArgs> OnAction;

        /// <summary>
        /// Fired off anytime the player does something such as 
        /// open team / global chat
        /// </summary>
        public event EventHandler<PlayerInteractionEventArgs> OnInteract;
        #endregion

        #region Members
        /// <summary>
        /// The keybinding profile to use.
        /// </summary>
        private PlayerInputProfile inputProfile;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the player input controller
        /// that uses the passed in input profile.
        /// </summary>
        /// <param name="inputProfile">The profile for key bindings.</param>
        public PlayerInputController(PlayerInputProfile inputProfile) {
            this.inputProfile = inputProfile;
        }
        #endregion
    }
}

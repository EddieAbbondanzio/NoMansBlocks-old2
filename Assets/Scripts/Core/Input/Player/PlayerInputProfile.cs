using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Core.Input.Player {
    /// <summary>
    /// Input profile for when the player is playing the game.
    /// </summary>
    public sealed class PlayerInputProfile : IInputProfile {
        #region Properties
        /// <summary>
        /// Key to move the player forwards
        /// </summary>
        public KeyCode MoveForward { get; set; }

        /// <summary>
        /// Key to move the player backwards.
        /// </summary>
        public KeyCode MoveBackwards { get; set; }

        /// <summary>
        /// Key to move the player to the left.
        /// </summary>
        public KeyCode StrafeLeft { get; set; }

        /// <summary>
        /// Key to move the player to the right.
        /// </summary>
        public KeyCode StrafeRight { get; set; }

        /// <summary>
        /// Key to invoke a jump.
        /// </summary>
        public KeyCode Jump { get; set; }

        /// <summary>
        /// Key to stand up, or crouch if lying down.
        /// </summary>
        public KeyCode StandUp { get; set; }

        /// <summary>
        /// Key to crouch, or laydown if already crouching.
        /// </summary>
        public KeyCode Crouch { get; set; }

        /// <summary>
        /// Key to switch to running.
        /// </summary>
        public KeyCode Run { get; set; }

        /// <summary>
        /// Key to open up the team chat.
        /// </summary>
        public KeyCode TeamChat { get; set; }

        /// <summary>
        /// Key to open up the global chat.
        /// </summary>
        public KeyCode GlobalChat { get; set; }
        #endregion
    }
}

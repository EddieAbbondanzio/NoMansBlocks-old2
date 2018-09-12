using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input {
    /// <summary>
    /// Checks the current state of input from the user.
    /// </summary>
    public sealed class UnityInputPoller : IInputPoller {
        #region Publics
        /// <summary>
        /// Checks if the button was pressed starting on
        /// this frame.
        /// </summary>
        /// <param name="code">The keycode to check.</param>
        /// <returns>True if the key was just pressed.</returns>
        public bool IsButtonDown(KeyCode code) {
            return UnityEngine.Input.GetKeyDown(code);
        }

        /// <summary>
        /// Checks if the button is currently pressed.
        /// </summary>
        /// <param name="code">The keycode to check.</param>
        /// <returns>True if the key is currently pressed.</returns>
        public bool IsButtonPressed(KeyCode code) {
            return UnityEngine.Input.GetKey(code);
        }

        /// <summary>
        /// Checks if the button is being released this frame.
        /// </summary>
        /// <param name="code">The keycode to check.</param>
        /// <returns></returns>
        public bool IsButtonUp(KeyCode code) {
            return UnityEngine.Input.GetKeyUp(code);
        }
        #endregion
    }
}

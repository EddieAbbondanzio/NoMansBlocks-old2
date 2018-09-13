using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input {
    /// <summary>
    /// Checks the input from the user to determine
    /// if specific keys are changing state, or axises
    /// are being manipulated, etc..
    /// </summary>
    public interface IInputPoller {
        #region Publics
        /// <summary>
        /// Checks if the button was pressed starting on
        /// this frame.
        /// </summary>
        /// <param name="code">THe keycode to check.</param>
        /// <returns>True if the key was just pressed.</returns>
        bool IsButtonDown(KeyCode code);

        /// <summary>
        /// Checks if the button is currently pressed.
        /// </summary>
        /// <param name="code">The keycode to check.</param>
        /// <returns>True if the key is currently pressed.</returns>
        bool IsButtonPressed(KeyCode code);

        /// <summary>
        /// Checks if the button is being released this frame.
        /// </summary>
        /// <param name="code">The keycode to check.</param>
        /// <returns></returns>
        bool IsButtonUp(KeyCode code);

        /// <summary>
        /// Checks if the mouse button is being presssed
        /// down this frame.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <returns>True if being depressed this frame.</returns>
        bool IsMouseButtonDown(int button);

        /// <summary>
        /// Checks if the mouse button is currently pressed on
        /// this frame.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <returns>True if the button is pressed.</returns>
        bool IsMouseButtonPressed(int button);

        /// <summary>
        /// Checks if the mouse button s being released this frame.
        /// </summary>
        /// <param name="button">The button to check.</param>
        /// <returns>True if being released</returns>
        bool IsMouseButtonUp(int button);
        #endregion
    }
}

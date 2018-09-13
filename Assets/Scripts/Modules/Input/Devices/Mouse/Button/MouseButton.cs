using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Enum to represent the three possible mouse buttons.
    /// </summary>
    public enum MouseButton : byte {
        Left   = 0,
        Right  = 1,
        Middle = 2,
    }

    /// <summary>
    /// Container for creating extensions for the MouseButton
    /// enum. Nothing else should be put here.
    /// </summary>
    public static class MouseButtonExtensions {
        /// <summary>
        /// Takes a mouse button and converts it to 
        /// Unity's KeyCode variant.
        /// </summary>
        /// <param name="button">The mouse button to convert to.</param>
        /// <returns>The Unity Keycode variant.</returns>
        public static KeyCode ToKeyCode(this MouseButton button) {
            switch (button) {
                case MouseButton.Left:
                    return KeyCode.Mouse0;
                case MouseButton.Right:
                    return KeyCode.Mouse1;
                case MouseButton.Middle:
                    return KeyCode.Mouse2;
                default:
                    throw new Exception(string.Format("Mouse button of {0} is not supported.", button.ToString()));
            }
        }
    }
}

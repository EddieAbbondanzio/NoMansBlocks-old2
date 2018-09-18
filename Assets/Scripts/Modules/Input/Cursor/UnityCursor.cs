using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input {
    /// <summary>
    /// Unity dependent version of the mouse cursor.
    /// </summary>
    public sealed class UnityCursor : ICursor {
        /// <summary>
        /// If the cursor is current set to be displayed
        /// on screen so the user can see it.
        /// </summary>
        public bool IsVisible {
            get { return Cursor.visible; }
            set { Cursor.visible = value; }
        }

        /// <summary>
        /// If the cursor is locked so that it is always
        /// kept at the center of the screen.
        /// </summary>
        public bool IsLocked {
            get { return Cursor.lockState == CursorLockMode.Locked; }
            set { Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None; }
        }

        /// <summary>
        /// The position of the cursor in pixels. (0,0) 
        /// is the top left corner of the screen.
        /// </summary>
        public Vector3 ScreenPosition {
            get { return UnityEngine.Input.mousePosition; }
        }
    }
}

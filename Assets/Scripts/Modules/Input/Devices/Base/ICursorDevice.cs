using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Interface for a cursor controlling device to implement.
    /// </summary>
    public interface ICursorDevice {
        #region Properties
        /// <summary>
        /// Lock the cursor in the center of the screen.
        /// </summary>
        bool LockCursor { get; set; }

        /// <summary>
        /// If the cursor should be displayed on screen.
        /// </summary>
        bool ShowCursor { get; set; }

        /// <summary>
        /// The cursors current position on the screen in
        /// pixels. 0,0 is top left.
        /// </summary>
        Vector3 CursorPosition { get; set; }
        #endregion
    }
}

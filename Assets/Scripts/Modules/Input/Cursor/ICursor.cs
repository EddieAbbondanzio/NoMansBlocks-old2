using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input {
    /// <summary>
    /// Interface for an on screen cursor to derive from.
    /// </summary>
    public interface ICursor {
        #region Properties
        /// <summary>
        /// If the cursor is current set to be displayed
        /// on screen so the user can see it.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// If the cursor is locked so that it is always
        /// kept at the center of the screen.
        /// </summary>
        bool IsLocked { get; set; }

        /// <summary>
        /// The position of the cursor in pixels. (0,0) 
        /// is the top left corner of the screen.
        /// </summary>
        Vector3 ScreenPosition { get; }
        #endregion
    }
}

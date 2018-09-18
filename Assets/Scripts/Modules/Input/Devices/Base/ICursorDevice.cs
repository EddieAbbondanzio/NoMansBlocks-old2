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
        /// The cursor that this device can control.
        /// </summary>
        ICursor Cursor { get; }
        #endregion
    }
}

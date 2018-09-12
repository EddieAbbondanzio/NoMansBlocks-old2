using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Enums for the possible input axes of
    /// the standard computer mouse.
    /// </summary>
    public enum MouseAxis : byte {
        Horizontal,
        Vertical,
        ScrollWheel,
    }
}

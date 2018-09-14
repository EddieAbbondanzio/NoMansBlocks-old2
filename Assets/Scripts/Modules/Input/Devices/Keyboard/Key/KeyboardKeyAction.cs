using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// The various types of keyboard events possible.
    /// </summary>
    public enum KeyboardKeyAction : byte {
        Down    = 0,    //Key is being pressed down this frame.
        Pressed = 1,    //Key is currently depressed
        Up      = 2,    //Key is being released this frame.
    }
}

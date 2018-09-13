using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// The various types of mouse button events possible.
    /// </summary>
    public enum MouseButtonAction {
        Down   ,    //Key is being pressed down this frame.
        Pressed,    //Key is currently depressed
        Up     ,    //Key is being released this frame.
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Delegate template to use for listeners subscribe to input from the 
    /// keyboard input controller script.
    /// </summary>
    /// <param name="key">The key that was interacted with.</param>
    /// <param name="action">The action that was performed.</param>
    public delegate void KeyboardKeyListener(KeyboardKey key, KeyboardKeyAction action);
}

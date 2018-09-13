using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Delegate template to use for listeners that subscribe to input
    /// from the mouse controller script.
    /// </summary>
    /// <param name="button">The button that was clicked.</param>
    /// <param name="action">The action event.</param>
    public delegate void MouseButtonListener(MouseButton button, MouseButtonAction action);
}

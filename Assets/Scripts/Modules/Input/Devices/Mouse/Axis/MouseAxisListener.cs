using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Delegate template to use for listeners that subscribe to input
    /// axes from the mouse controller script.
    /// </summary>
    /// <param name="axis">The mouse axis in action.</param>
    /// <param name="value">It's current value.</param>
    public delegate void MouseAxisListener(MouseAxis axis, float value);
}

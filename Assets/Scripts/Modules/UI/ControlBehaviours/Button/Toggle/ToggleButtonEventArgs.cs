using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Arguments to pass the state of a toggle button around 
    /// via events
    /// </summary>
    public sealed class ToggleButtonEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The current state of the button.
        /// </summary>
        public ToggleButtonState State { get; }
        #endregion

        #region Constructor(s)
        public ToggleButtonEventArgs(ToggleButtonState state) {
            State = state;
        }
        #endregion
    }
}

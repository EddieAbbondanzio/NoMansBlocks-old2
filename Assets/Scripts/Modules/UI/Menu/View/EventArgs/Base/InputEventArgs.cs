using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.View {
    /// <summary>
    /// Base class for arguments related to events that were triggered
    /// by a UI Control.
    /// </summary>
    public abstract class InputEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The name of the control that fired off this event.
        /// </summary>
        public string ControlName { get; }

        /// <summary>
        /// The type of control that fired off this event.
        /// </summary>
        public abstract ControlType ControlType { get; }

        /// <summary>
        /// The type of action that occured.
        /// </summary>
        public abstract InputActionType ActionType { get; }
        #endregion

        #region Constructor(s)
        protected InputEventArgs(string controlName) {
            ControlName = controlName;
        }
        #endregion
    }
}

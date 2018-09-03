using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.View {
    /// <summary>
    /// Arguments for a trigger button control that was clicked.
    /// </summary>
    public sealed class TriggerButtonEventArgs : InputEventArgs {
        #region Properties
        /// <summary>
        /// The type of control being acted upon.
        /// </summary>
        public override ControlType ControlType => ControlType.TriggerButton;

        /// <summary>
        /// The type of action that occured.
        /// </summary>
        public override InputActionType ActionType => InputActionType.Click;
        #endregion

        #region Constructor(s)
        public TriggerButtonEventArgs(string controlName) : base(controlName) {
        }
        #endregion
    }
}

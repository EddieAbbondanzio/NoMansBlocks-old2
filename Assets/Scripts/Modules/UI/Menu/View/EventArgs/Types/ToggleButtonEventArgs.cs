using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.View {
    /// <summary>
    /// Arguments for a toggle button control that has changed
    /// state.
    /// </summary>
    public sealed class ToggleButtonEventArgs : InputEventArgs {
        #region Properties
        /// <summary>
        /// The type of control being acted upon.
        /// </summary>
        public override ControlType ControlType => ControlType.ToggleButton;

        /// <summary>
        /// The type of action that occured.
        /// </summary>
        public override InputActionType ActionType => InputActionType.Click;

        /// <summary>
        /// If the toggle button is currently toggled in
        /// the active state.
        /// </summary>
        public bool IsToggled { get; }
        #endregion

        #region Constructor(s)
        public ToggleButtonEventArgs(string controlName, bool isToggled) : base (controlName) {
            IsToggled = isToggled;
        }
        #endregion
    }
}

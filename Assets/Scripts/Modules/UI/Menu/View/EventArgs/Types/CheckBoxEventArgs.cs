using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.View {
    /// <summary>
    /// Arguments for passing around a checkbox that has changed it's
    /// state.
    /// </summary>
    public sealed class CheckBoxEventArgs : InputEventArgs {
        #region Properties
        /// <summary>
        /// The type of control being acted upon.
        /// </summary>
        public override ControlType ControlType => ControlType.CheckBox;

        /// <summary>
        /// The type of action that occured.
        /// </summary>
        public override InputActionType ActionType => InputActionType.Click;

        /// <summary>
        /// If the checkbox is current checked or not.
        /// </summary>
        public bool IsChecked { get; }
        #endregion

        #region Constructor(s)
        public CheckBoxEventArgs(string controlName, bool isChecked) : base(controlName) {
            IsChecked = isChecked;
        }
        #endregion
    }
}

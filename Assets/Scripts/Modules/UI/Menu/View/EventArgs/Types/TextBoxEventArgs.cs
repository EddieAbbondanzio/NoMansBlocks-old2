using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.View {
    /// <summary>
    /// Event arguments for a textbox that had it's text changed, 
    /// or finished being editted.
    /// </summary>
    public sealed class TextBoxEventArgs : InputEventArgs {
        #region Properties
        /// <summary>
        /// The type of control being acted upon.
        /// </summary>
        public override ControlType ControlType => ControlType.TextBox;

        /// <summary>
        /// The type of action that occured.
        /// </summary>
        public override InputActionType ActionType { get; }

        /// <summary>
        /// The current text value in the text box.
        /// </summary>
        public string Text { get; }
        #endregion

        #region Constructor(s)
        public TextBoxEventArgs(string controlName, InputActionType actionType, string text) : base (controlName) {
            ActionType = actionType;
            Text = text;
        }
        #endregion
    }
}

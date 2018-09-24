using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Arguments for passing around text box contents.
    /// </summary>
    public sealed class TextBoxEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The text from the textbox.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// THe type of action that was performed on the textbox.
        /// </summary>
        public TextBoxAction Action { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of text box event args for passing
        /// around the textboxes content.
        /// </summary>
        /// <param name="text">The text of the box.</param>
        /// <param name="action">The action that was performed.</param>
        public TextBoxEventArgs(string text, TextBoxAction action) {
            Text = text;
            Action = action;
        }
        #endregion
    }
}

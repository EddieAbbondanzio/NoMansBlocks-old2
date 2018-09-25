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
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of text box event args for passing
        /// around the textboxes content.
        /// </summary>
        /// <param name="text">The text of the box.</param>
        public TextBoxEventArgs(string text) {
            Text = text;
        }
        #endregion
    }
}

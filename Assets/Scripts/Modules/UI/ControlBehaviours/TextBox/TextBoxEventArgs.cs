using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Arguments for passing around the value of a 
    /// textbox.
    /// </summary>
    public sealed class TextBoxEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The text of the textbox.
        /// </summary>
        public string Text { get; }
        #endregion

        #region Constructor(s)
        public TextBoxEventArgs(string text) {
            Text = text;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Interface for textbox based controls to derive from.
    /// </summary>
    public interface ITextBox : IControl, IFocusable {
        #region Properties
        /// <summary>
        /// The text inside of the textbox
        /// </summary>
        string Text { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired everytime the value of the textbox is changed.
        /// </summary>
        event EventHandler<TextBoxEventArgs> OnEdit;

        /// <summary>
        /// Fired when the user has finished performing an edit.
        /// </summary>
        event EventHandler<TextBoxEventArgs> OnEndEdit;
        #endregion

        #region Publics
        /// <summary>
        /// Clear out the contents of the textbox.
        /// </summary>
        void Clear();
        #endregion
    }
}

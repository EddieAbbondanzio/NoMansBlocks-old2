using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Event args for passing around the value of
    /// a check box.
    /// </summary>
    public sealed class CheckBoxEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// If the checkbox is currently checked.
        /// </summary>
        public bool IsChecked { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of check box event args.
        /// </summary>
        /// <param name="isChecked">True if checked.</param>
        public CheckBoxEventArgs(bool isChecked) {
            IsChecked = isChecked;
        }
        #endregion
    }
}

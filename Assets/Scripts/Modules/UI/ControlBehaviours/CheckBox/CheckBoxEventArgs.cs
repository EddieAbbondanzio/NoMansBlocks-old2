using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Arguments to pass around the checked state of a 
    /// CheckBox UI via events.
    /// </summary>
    public sealed class CheckBoxEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// If the checkbox is currently checked.
        /// </summary>
        public bool IsChecked { get; }
        #endregion

        #region Constructor(s)
        public CheckBoxEventArgs(bool isChecked) {
            IsChecked = isChecked;
        }
        #endregion
    }
}

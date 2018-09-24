using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Interface for checkbox based controls to derive from.
    /// </summary>
    public interface ICheckBox : IControl, IFocusable {
        #region Properties
        /// <summary>
        /// If the checkbox is currently checked or not.
        /// </summary>
        bool IsChecked { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired everytime the checked status of the box is changed.
        /// </summary>
        event EventHandler OnCheckChange;
        #endregion
    }
}

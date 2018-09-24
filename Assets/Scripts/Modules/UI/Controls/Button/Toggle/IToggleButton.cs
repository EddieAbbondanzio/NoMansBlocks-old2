using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Interface for a button that toggles it's states
    /// to derive from.
    /// </summary>
    public interface IToggleButton : IControl, IFocusable {
        #region Properties
        /// <summary>
        /// If the button is currently toggled on.
        /// </summary>
        bool IsToggled { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired when the state of the button flip flops from
        /// Enabled to Disabled, or vice versa.
        /// </summary>
        event EventHandler OnToggle;
        #endregion
    }

}

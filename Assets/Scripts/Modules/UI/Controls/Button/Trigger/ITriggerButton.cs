using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Interface for standard buttons that don't track their
    /// state and simply fire off a click event to derive from.
    /// </summary>
    public interface ITriggerButton : IControl, IFocusable {
        #region Event Delegates
        /// <summary>
        /// Fired whenever the user clicks on the button.
        /// </summary>
        event EventHandler OnClick;
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Presenter {
    /// <summary>
    /// Arguments to pass around a control and the action that
    /// were performed on it.
    /// </summary>
    public sealed class InputEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The control that fired off the event.
        /// </summary>
        public IControlPresenter Control { get; }

        /// <summary>
        /// The type of action that occured.
        /// </summary>
        public InputActionType ActionType { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of arguments pertaining to a control
        /// that the user interacted with.
        /// </summary>
        /// <param name="control">The control firing off the event.</param>
        /// <param name="actionType">What was done to it.</param>
        public InputEventArgs(IControlPresenter control, InputActionType actionType) {
            Control = control;
            ActionType = actionType;
        }
        #endregion
    }
}

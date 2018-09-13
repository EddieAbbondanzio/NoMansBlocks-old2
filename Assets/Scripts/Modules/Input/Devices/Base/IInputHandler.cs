using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// An input handler is a object that handles a single source of
    /// input such as an axis, or button.
    /// </summary>
    public interface IInputHandler {
        #region Publics
        /// <summary>
        /// Update the state of the input handler
        /// using the poller passed in.
        /// </summary>
        /// <param name="inputPoller">Allows for checking current input state.</param>
        void Update(IInputPoller inputPoller);
        #endregion
    }
}

using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Input {
    /// <summary>
    /// Interface to abstract away the underlying details. Useful class
    /// for finding controls in a menu view.
    /// </summary>
    public interface IInputControlCoordinator {
        #region Publics
        /// <summary>
        /// Search for a specific control in the view.
        /// </summary>
        /// <typeparam name="T">The control type to look for.</typeparam>
        /// <param name="name">The name of the control</param>
        /// <returns>The control if found</returns>
        T GetControl<T>(string name) where T : class, IControlHandler;

        /// <summary>
        /// Search for all controls of a specific type.
        /// </summary>
        /// <typeparam name="T">The type to hunt for.</typeparam>
        /// <returns>The controls of the matching type</returns>
        List<T> GetControls<T>() where T : class, IControlHandler;
        #endregion
    }
}

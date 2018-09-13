using NoMansBlocks.Modules.Input;
using NoMansBlocks.Modules.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Interface for a service locater that handles
    /// locating all dependencies for the game engine.
    /// </summary>
    public interface IServiceLocator {
        #region Publics
        /// <summary>
        /// Returns the instance of a logger to use.
        /// </summary>
        /// <returns>The logger to log with.</returns>
        ILogger GetLogger();

        /// <summary>
        /// Returns an instance of the input poller to
        /// use.
        /// </summary>
        /// <returns>The input poller to check input state.</returns>
        IInputPoller GetInputPoller();
        #endregion
    }
}

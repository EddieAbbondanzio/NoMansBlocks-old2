using NoMansBlocks.Modules.Input;
using NoMansBlocks.Modules.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine{
    /// <summary>
    /// Locates all the unity specific services for the game
    /// engine. This allows us to inject all our dependencies.
    /// </summary>
    public sealed class UnityServiceLocator : IServiceLocator {
        #region Publics
        /// <summary>
        /// Returns an instance of a Unity logger to use to
        /// generate log files with.
        /// </summary>
        /// <returns>The Unity logger to use.</returns>
        public ILogger GetLogger() {
            return new UnityLogger();
        }

        /// <summary>
        /// Returns an instance of a Unity Input Poller to check
        /// the current input state with.
        /// </summary>
        /// <returns>The Unity Input Poller to use.</returns>
        public IInputPoller GetInputPoller() {
            return new UnityInputPoller();
        }
        #endregion
    }
}

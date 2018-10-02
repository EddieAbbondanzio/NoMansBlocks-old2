using NoMansBlocks.Modules.Input;
using NoMansBlocks.Modules.Logging;
using NoMansBlocks.Modules.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Locates all the unity specific services for the game
    /// engine. This allows us to inject all our dependencies.
    /// </summary>
    public sealed class UnityServiceLocator : ServiceLocator {
        #region Helpers
        /// <summary>
        /// Initialize all the services for use.
        /// </summary>
        protected override void InitServices() {
            Logger      = new UnityLogger();
            InputPoller = new UnityInputPoller();
            UserService = new TestUserService();
        }
        #endregion
    }
}

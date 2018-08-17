using NoMansBlocks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Services {
    /// <summary>
    /// Module to contain all of the services needed by the engine.
    /// These are used to interact with the master server for accounts
    /// and more.
    /// </summary>
    public class ServiceModule : Module {
        #region Properties
        /// <summary>
        /// Login and register service for user accounts.
        /// </summary>
        public UserService UserService { get; private set; }
        #endregion
    }
}

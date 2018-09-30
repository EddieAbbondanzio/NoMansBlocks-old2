using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Container that holds all the various modules needed by the game
    /// engine at any time.
    /// </summary>
    public interface IConfigContainer {
        #region Publics
        /// <summary>
        /// Get the specific config desired. If the config is not
        /// found, a default instance will be returned.
        /// </summary>
        /// <typeparam name="T">The config type to hunt for.</typeparam>
        /// <returns>The config (if any).</returns>
        T GetConfig<T>() where T : class, IConfig;

        /// <summary>
        /// Set the config into the config module. If a config of the same
        /// type already exists, then it will be overwritten.
        /// </summary>
        /// <typeparam name="T">The type of the config.</typeparam>
        /// <param name="config">The config to store.</param>
        void SetConfig<T>(T config) where T : class, IConfig;
        #endregion
    }
}

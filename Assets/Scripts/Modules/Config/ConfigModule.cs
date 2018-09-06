using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Module for handling the various configs for both the server and
    /// client. Handles loading and saving them to file when the game is
    /// started and stopped.
    /// </summary>
    public sealed class ConfigModule : Module {
        #region Constants
        /// <summary>
        /// The name to use for loading the config file from memory.
        /// </summary>
        private const string ConfigFileName = "config.json";
        #endregion

        #region Members
        /// <summary>
        /// The filehandler for loading in the config file.
        /// </summary>
        private ConfigFileHandler fileHandler;

        /// <summary>
        /// The collection of configs that were loaded from the file.
        /// </summary>
        private List<IConfig> configs;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the config module.
        /// </summary>
        /// <param name="engine">The parent engine that owns this module.</param>
        public ConfigModule(GameEngine engine) : base (engine) {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Get the specific config desired.
        /// </summary>
        /// <typeparam name="T">The config type to hunt for.</typeparam>
        /// <returns>The config (if any).</returns>
        public T GetConfig<T>() where T : class, IConfig {
            for(int i = 0; i < configs.Count; i++) {
                if(configs[i].GetType() == typeof(T)) {
                    return configs[i] as T;
                }
            }

            return null;
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// When the engine first starts up try to pull 
        /// in the config file.
        /// </summary>
        public async override void OnInit() {
            fileHandler = new ConfigFileHandler();

            if (fileHandler.Exists(ConfigFileName)) {
                ConfigFile configFile = await fileHandler.LoadAsync(ConfigFileName);
                configs = configFile.Content;
            }
            else {
                configs = new List<IConfig>();
            }
        }

        /// <summary>
        /// When the engine is shutting down save the config file
        /// to memory.
        /// </summary>
        public async override void OnEnd() {
            ConfigFile configFile = fileHandler.Create(ConfigFileName);
            configFile.Content = configs;

            await fileHandler.SaveAsync(configFile);
        }
        #endregion
    }
}

using NoMansBlocks.Core.Engine;
using NoMansBlocks.FileIO;
using NoMansBlocks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Module for handling the various configs for both the server and
    /// client. Handles loading and saving them to file when the game is
    /// started and stopped.
    /// </summary>
    public sealed class ConfigModule : Core.Engine.Module, IConfigContainer {
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
        private FileHandler<ConfigFile> fileHandler;

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
        /// Get the specific config desired. If the config is not
        /// found, a default instance will be returned.
        /// </summary>
        /// <typeparam name="T">The config type to hunt for.</typeparam>
        /// <returns>The config (if any).</returns>
        public T GetConfig<T>() where T : class, IConfig {
            if (configs == null) {
                throw new InvalidOperationException("Config module has not been initialized.");
            }

            //See if we already have it, and it is supported for this engine.
            for (int i = 0, configCount = configs.Count; i < configCount; i++) {
                if(ReflectionUtils.IsSubType(configs[i].GetType(), typeof(T)) && (configs[i].EngineType & Engine.Type) > 0) {
                    return configs[i] as T;
                }
            }

            T config = Activator.CreateInstance(typeof(T)) as T;

            if (config == null || (config.EngineType & Engine.Type) == 0) {
                throw new Exception(string.Format("No config of type {0} found to support this engine type {1}", typeof(T), Engine.Type));
            }

            config.ResetToDefault(Engine.Type);
            configs.Add(config);
            return config;
        }

        /// <summary>
        /// Set the config into the config module. If a config of the same
        /// type already exists, then it will be overwritten.
        /// </summary>
        /// <typeparam name="T">The type of the config.</typeparam>
        /// <param name="config">The config to store.</param>
        public void SetConfig<T>(T config) where T : class, IConfig {
            if(configs == null) {
                throw new InvalidOperationException("Config module has not been initialized.");
            }

            //See if the config is already in the module.
            for (int i = 0, configCount = configs.Count; i < configCount; i++) {
                if(ReflectionUtils.IsSubType(configs[i].GetType(), typeof(T))) {
                    configs[i] = config;
                    return;
                }
            }

            //Not found, need to add it.
            configs.Add(config);
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// When the engine first starts up try to pull 
        /// in the config file.
        /// </summary>
        public override void OnInit() {
            fileHandler = new FileHandler<ConfigFile>();

            if (fileHandler.Exists(ConfigFileName)) {
                try {
                    //Design flaw.
                    ConfigFile configFile = fileHandler.LoadAsync(ConfigFileName).Result;
                    configs = configFile.Content;

                    //Validate everything, when we find bad data just reset to defaults.
                    for(int i = 0; i < configs.Count; i++) {
                        if (!configs[i].Validate(Engine.Type)) {
                            configs[i].ResetToDefault(Engine.Type);
                        }
                    }

                    return;
                }
                catch (Exception e) {
                    Log.Debug("Failed to pull in the config file. Resetting to defaults");
                    Log.Error(e);
                }
            }

            configs = new List<IConfig>();
        }

        /// <summary>
        /// When the engine is shutting down save the config file
        /// to memory.
        /// </summary>
        public async override void OnEnd() {
            Log.Debug("Config count is {0}", configs.Count);
            ConfigFile configFile = fileHandler.Create(ConfigFileName);
            configFile.Content = configs;

            await fileHandler.SaveAsync(configFile);
        }
        #endregion
    }
}

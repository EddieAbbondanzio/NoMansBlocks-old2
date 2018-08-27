using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.Serialization;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// A server instance of the no mans block game engine.
    /// </summary>
    public sealed class ServerEngine : GameEngine {
        #region Properties
        /// <summary>
        /// Flag indicating what kind of engine it is.
        /// </summary>
        public override GameEngineType Type => GameEngineType.Server;

        /// <summary>
        /// The config settings for the file.
        /// </summary>
        public ServerConfig Config { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the server game engine.
        /// <paramref name="engineTicker">The engine game loop.</paramref>
        /// </summary>
        public ServerEngine(IGameEngineTicker engineTicker) : base(engineTicker) {
        }
        #endregion

        #region Engine Events
        /// <summary>
        /// Called when the engine is first starting up. This goes out 
        /// and attempts to load the configuration file.
        /// </summary>
        protected async override void OnInit() {
            Config = await LoadConfig();

            NetModule = new NetModule(this, Config.Capacity, Config.Port);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Attempt to load the config from file if it exists, else just use
        /// the default settings.
        /// </summary>
        /// <returns>The loaded configurations to use.</returns>
        private async Task<ServerConfig> LoadConfig() {
            FileHandler<ConfigFile> configFileHandler = new FileHandler<ConfigFile>();

            //Load in the server settings.
            if (configFileHandler.Exists("serverconfig.json")) {
                var configFile = await configFileHandler.Load("serverconfig.json");
                return configFile.Content;
            }
            else {
                return ServerConfig.DefaultConfig;
            }
        }
    }
    #endregion
}

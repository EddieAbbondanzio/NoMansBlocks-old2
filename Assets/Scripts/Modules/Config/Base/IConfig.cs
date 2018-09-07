using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Interface for all config objects to derive from.
    /// This indicates that we can store them in the config
    /// module.
    /// </summary>
    public interface IConfig {
        #region Properties
        /// <summary>
        /// What type of engine this config file is for.
        /// </summary>
        GameEngineType EngineType { get; }

        /// <summary>
        /// The type of config object it is.
        /// </summary>
        ConfigType ConfigType { get; }

        /// <summary>
        /// Reset the config file back to it's defaults for
        /// the engine type passed in.
        /// </summary>
        /// <param name="engineType">The engine type to reset
        /// defaults to.</param>
        void ResetToDefault(GameEngineType engineType);
        #endregion
    }
}

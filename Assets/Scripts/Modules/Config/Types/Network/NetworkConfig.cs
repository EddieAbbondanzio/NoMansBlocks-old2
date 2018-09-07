using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Core.Engine;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Settings that pertain to the network module.
    /// </summary>
    public abstract class NetworkConfig : IConfig {
        #region Properties
        /// <summary>
        /// The type of config object it is.
        /// </summary>
        public ConfigType ConfigType => ConfigType.Network;

        /// <summary>
        /// The type of engine this network config supports
        /// </summary>
        public abstract GameEngineType EngineType { get; }
        
        /// <summary>
        /// The port number to listen on.
        /// </summary>
        public abstract int Port { get; set; }

        /// <summary>
        /// The maximum number of connections to allow.
        /// </summary>
        public abstract int ConnectionCapacity { get; set; }
        #endregion

        #region Publics
        /// <summary>
        /// Reset the network configs back their default
        /// settings based on the engine type.
        /// </summary>
        /// <param name="engineType">The type of engine running.</param>
        public abstract void ResetToDefault(GameEngineType engineType);
        #endregion
    }
}

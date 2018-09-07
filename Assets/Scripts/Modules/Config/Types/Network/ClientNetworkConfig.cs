using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Core.Engine;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Network settings for the client.
    /// </summary>
    [Serializable]
    public sealed class ClientNetworkConfig : NetworkConfig {
        #region Properties
        /// <summary>
        /// The type of engine this network config supports
        /// </summary>
        public override GameEngineType EngineType => GameEngineType.Client;

        /// <summary>
        /// The port to listen on.
        /// </summary>
        public override int Port { get; set; }

        /// <summary>
        /// The maximum number of connections allowed.
        /// </summary>
        public override int ConnectionCapacity { get; set; }
        #endregion

        #region Publics
        /// <summary>
        /// Reset the config back to it's default.
        /// </summary>
        /// <param name="engineType">The type of engine to reset it as.</param>
        public override void ResetToDefault(GameEngineType engineType) {
            Port = 0;
            ConnectionCapacity = 1;
        }
        #endregion
    }
}

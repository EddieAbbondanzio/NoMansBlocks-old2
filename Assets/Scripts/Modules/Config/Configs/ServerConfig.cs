using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// The configuration settings of the server.
    /// </summary>
    [Serializable]
    public class ServerConfig : IConfig {
        #region Properties
        /// <summary>
        /// Flag to indicate what kind of config object it is.
        /// </summary>
        public ConfigType ConfigType => ConfigType.Server;

        /// <summary>
        /// The name to show in the chat when the server
        /// performs an action.
        /// </summary>
        public string ChatName { get; set; } = "Admin";

        /// <summary>
        /// The port to listen for connections on.
        /// </summary>
        public int Port { get; set; } = 9550;

        /// <summary>
        /// The maximum number of connections allowed
        /// with the server.
        /// </summary>
        public int Capacity { get; set; }
        #endregion
    }
}

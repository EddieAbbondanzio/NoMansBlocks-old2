using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// The configuration settings of the server.
    /// </summary>
    [Serializable]
    public class ServerConfig {
        #region Statics
        /// <summary>
        /// The default settings for the server to use.
        /// </summary>
        public static ServerConfig DefaultConfig = new ServerConfig() {
            ChatName = "Admin",
            Port     = 9550,
        };
        #endregion

        #region Properties
        /// <summary>
        /// The name to show in the chat when the server
        /// performs an action.
        /// </summary>
        [JsonProperty]
        public string ChatName { get; set; }

        /// <summary>
        /// The port to listen for connections on.
        /// </summary>
        [JsonProperty]
        public int Port { get; set; }

        /// <summary>
        /// The maximum number of connections allowed
        /// with the server.
        /// </summary>
        [JsonProperty]
        public int Capacity { get; set; }
        #endregion
    }
}

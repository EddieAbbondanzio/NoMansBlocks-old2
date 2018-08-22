using NoMansBlocks.Core.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// A config file holds the Server Config settings for later
    /// retrieval.
    /// </summary>
    public class ConfigFile : JsonFile<ServerConfig> {
        #region Constructor(s)
        /// <summary>
        /// Create a new empty Server Config file.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        public ConfigFile(FileInfo info) : base(info) {
        }

        /// <summary>
        /// Create a new populated config file using the 
        /// server config passed in.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        /// <param name="config">The server config to store in the file.</param>
        public ConfigFile(FileInfo info, ServerConfig config) : base(info, config) {
        }

        /// <summary>
        /// Deserialize a config file from disk.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        /// <param name="content">The raw content of the file.</param>
        public ConfigFile(FileInfo info, byte[] content) : base (info, content) {
        }
        #endregion
    }
}

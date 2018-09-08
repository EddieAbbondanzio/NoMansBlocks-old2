using Newtonsoft.Json;
using NoMansBlocks.Core.FileIO;
using NoMansBlocks.Core.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// The file that holds all of the configs.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(ConfigFileConverter))]
    public sealed class ConfigFile : JsonFile<List<IConfig>> {
        #region Constructor(s)
        /// <summary>
        /// Create a new empty config file.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        public ConfigFile(FileInfo info) : base(info) {
        }

        /// <summary>
        /// Create a new config file using the configs passed in.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        /// <param name="configs">The configs to store in it.</param>
        public ConfigFile(FileInfo info, List<IConfig> configs) : base (info, configs) {
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

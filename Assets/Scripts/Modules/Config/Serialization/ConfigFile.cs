using Newtonsoft.Json;
using NoMansBlocks.Core.Serialization;
using System;
using System.Collections.Generic;
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

        #endregion
    }
}

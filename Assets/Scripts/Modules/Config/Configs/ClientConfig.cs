using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// The configuration settings of the client.
    /// </summary>
    [Serializable]
    public class ClientConfig : IConfig {
        #region Properties
        /// <summary>
        /// Flag to indicate what kind of config object it is.
        /// </summary>
        public ConfigType ConfigType => ConfigType.Client;

        /// <summary>
        /// Range from 0-100 for the audio percentage.
        /// </summary>
        public int AudioLevel { get; set; }

        /// <summary>
        /// How bright the screen should be adjusted.
        /// </summary>
        public int Brightness { get; set; }
        #endregion
    }
}

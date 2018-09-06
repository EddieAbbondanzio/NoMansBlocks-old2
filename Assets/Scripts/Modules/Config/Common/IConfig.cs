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
        /// The type of config object it is.
        /// </summary>
        ConfigType ConfigType { get; }
        #endregion
    }
}

using NoMansBlocks.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Filehandler for mantaining the config file, 
    /// along with only allowing 1 at any time.
    /// </summary>
    public sealed class ConfigFileHandler : FileHandler<ConfigFile> {
        #region Properties
        public override string Directory => "config";

        /// <summary>
        /// Only 1 config file is permitted at any time.
        /// </summary>
        public override int Capacity => 1;
        #endregion
    }
}

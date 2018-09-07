using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Flag to indicate what kind of config object
    /// it is.
    /// </summary>
    public enum ConfigType {
        Client = 0,
        Server = 1,
        Network = 2,
    }
}

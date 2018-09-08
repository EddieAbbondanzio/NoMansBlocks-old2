using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Helper methods for managing Configs.
    /// </summary>
    public static class ConfigUtils {
        public static Type GetType(ConfigType configType) {
            switch (configType) {
                case ConfigType.Network:
                    return typeof(NetworkConfig);
                default:
                    throw new NotSupportedException(string.Format("Config Type of {0} is not supported by this method.", configType));
            }
        }
    }
}

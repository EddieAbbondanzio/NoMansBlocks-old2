using NoMansBlocks.Modules.Network;
using NoMansBlocks.Modules.UserSystem;
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
        Login   = 0,
        Network = 1,
    }

    /// <summary>
    /// Extension methods related to the ConfigType enum.
    /// </summary>
    public static class ConfigTypeExtensions {
        /// <summary>
        /// Retrieve the object type related to the config
        /// type passed in.
        /// </summary>
        /// <param name="configType">The config type.</param>
        /// <returns>The .NET object type related to the config type.</returns>
        public static Type GetObjectType(this ConfigType configType) {

            switch (configType) {
                case ConfigType.Network:
                    return typeof(NetworkConfig);
                case ConfigType.Login:
                    return typeof(LoginConfig);
                default:
                    throw new NotSupportedException(string.Format("Config Type of {0} is not supported by this method.", configType));
            }
        }
    }
}

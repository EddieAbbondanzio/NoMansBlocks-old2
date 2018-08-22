using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Utils {
    /// <summary>
    /// Utility methods for network related methods
    /// </summary>
    public static class NetUtils {
        /// <summary>
        /// Parse a NetEndPoint from a string input.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <returns>The extracted NetEndPoint.</returns>
        public static NetEndPoint ParseEndPointFromString(string input) {
            string[] splitInput = input.Split(':');

            if(splitInput.Length != 2) {
                throw new FormatException("Bad input string. Does not contain an end point.");
            }

            int port;
            if(int.TryParse(splitInput[1], out port)) {
                return new NetEndPoint(splitInput[0], port);
            }
            else {
                throw new FormatException("Unable to extract port.");
            }
        }
    }
}

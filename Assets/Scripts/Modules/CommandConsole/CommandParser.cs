using LiteNetLib;
using NoMansBlocks.Modules.CommandConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole {
    /// <summary>
    /// Parses commands from the user input.
    /// </summary>
    public class CommandParser {
        #region Publics
        /// <summary>
        /// Parse a string to extract a command from it.
        /// </summary>
        /// <param name="input">The command to extract.</param>
        /// <returns>The extracted command.</returns>
        public Command ParseCommand(string input) {
            string[] splitInput = input.Split(' ');
            string commandKey = splitInput[0].TrimStart('/');

            switch (commandKey) {
                case "connect":
                    NetEndPoint connectEndPoint = Utils.NetUtils.ParseEndPointFromString(splitInput[1]);
                    return new ConnectCommand(connectEndPoint);
                case "disconnect":
                    return new DisconnectCommand();
                default:
                    throw new FormatException("Invalid command. Unable to parse.");
            }
        }
        #endregion
    }
}

using NoMansBlocks.Modules.CommandConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole {
    /// <summary>
    /// Barebones interface for interacting with the Command Console
    /// Module. This prevents the holder from getting unneeded power.
    /// </summary>
    public interface ICommandConsole {
        #region Publics
        /// <summary>
        /// Parse and process a new command.
        /// </summary>
        /// <param name="command">The text of the command to parse.</param>
        void Execute(string command);

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        void Execute(Command command);
        #endregion
    }
}

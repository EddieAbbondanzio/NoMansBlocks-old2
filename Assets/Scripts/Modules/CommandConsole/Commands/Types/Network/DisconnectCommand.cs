using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UserSystem;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Disconnect command to disconnect a client from the server
    /// or shut down the server and disconnect all clients.
    /// </summary>
    public sealed class DisconnectCommand : Command {
        #region Properties
        /// <summary>
        /// The keyword that comes after the '/'.
        /// </summary>
        public override string Keyword => "disconnect";
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new disconnect command.
        /// </summary>
        public DisconnectCommand() {
        }
        #endregion

        #region Publics
#pragma warning disable 1998
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The currently running game engine.</param>
        /// <returns>True if no errors.</returns>
        public override async Task<bool> ExecuteAsync(GameEngine executingContext) {
            executingContext.NetModule.Disconnect();
            return true;
        }
#pragma warning restore 1998
        #endregion
    }
}

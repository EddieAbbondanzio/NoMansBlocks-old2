using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Disconnect command to disconnect a client from the server
    /// or shut down the server and disconnect all clients.
    /// </summary>
    public sealed class DisconnectCommand : Command {
        #region Properties
        /// <summary>
        /// The type of command it is.
        /// </summary>
        public override CommandType CommandType => CommandType.Disconnect;

        /// <summary>
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.All;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new disconnect command.
        /// </summary>
        public DisconnectCommand() {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext"></param>
        public override void Execute(GameEngine executingContext) {
            executingContext.NetModule.Disconnect();
        }

        /// <summary>
        /// Summarize the command in a print friendly format.
        /// </summary>
        /// <returns>The command in a string form.</returns>
        public override string Summarize() {
            return "/disconnect";
        }
        #endregion
    }
}

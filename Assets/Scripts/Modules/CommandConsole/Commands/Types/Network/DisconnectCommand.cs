using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.UserSystem;

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

        /// <summary>
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.All;

        /// <summary>
        /// The help tip to show for the help command.
        /// </summary>
        public override string HelpTip => "Disconnect all currently active network connections.";
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
        /// <param name="executingContext">The currently running game engine.</param>
        public override void Execute(GameEngine executingContext) {
            executingContext.NetModule.Disconnect();
        }
        #endregion
    }
}

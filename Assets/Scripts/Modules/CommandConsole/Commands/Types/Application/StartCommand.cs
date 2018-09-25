using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Command to start the game engine up.
    /// </summary>
    public sealed class StartCommand : Command {
        #region Properties
        /// <summary>
        /// The keyword that comes after the '/'.
        /// </summary>
        public override string Keyword => "start";

        /// <summary>
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.Admin;

        /// <summary>
        /// The help tip to show for the help command.
        /// </summary>
        public override string HelpTip => "Starts up the game engine.";
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The currently running game engine instance.</param>
        public override void Execute(GameEngine executingContext) {
            executingContext.Run();
        }
        #endregion
    }
}

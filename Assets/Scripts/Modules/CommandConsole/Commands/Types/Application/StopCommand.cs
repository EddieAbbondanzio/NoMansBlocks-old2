using NoMansBlocks.Core.Engine;
using NoMansBlocks.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Command to shut down the game engine.
    /// </summary>
    public sealed class StopCommand : Command {
        #region Properties
        /// <summary> 
        /// The keyword that comes after the '/'.
        /// </summary>
        public override string Keyword => "stop";

        /// <summary>                                  
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.Admin;

        /// <summary>
        /// The help tip to show for the help command.
        /// </summary>
        public override string HelpTip => "Shuts down the game engine.";
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The currently running game engine instance.</param>
        public override void Execute(GameEngine executingContext) {
            executingContext.Stop();
        }
        #endregion
    }
}

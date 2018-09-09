using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
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
        /// The type of command it is.
        /// </summary>
        public override CommandType CommandType => CommandType.Stop;

        /// <summary>
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.All;
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The currently running game engine instance.</param>
        public override void Execute(GameEngine executingContext) {
            executingContext.Stop();
        }

        /// <summary>
        /// Summarize the command in a print friendly format.
        /// </summary>
        /// <returns>The command in a string form.</returns>
        public override string Summarize() {
            return "/stop";
        }
        #endregion
    }
}

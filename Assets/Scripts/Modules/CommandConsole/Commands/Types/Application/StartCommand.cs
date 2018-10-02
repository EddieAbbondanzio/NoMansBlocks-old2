using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UserSystem;
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
        #endregion

        #region Publics
#pragma warning disable 1998
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The currently running game engine instance.</param>
        /// <returns>True if no errors.</returns>
        public override async Task<bool> ExecuteAsync(GameEngine executingContext) {
            executingContext.Run();
            return true;
        }
#pragma warning restore 1998
        #endregion
    }
}

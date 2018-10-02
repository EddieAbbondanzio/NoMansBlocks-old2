using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UserSystem;
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
        #endregion

        #region Publics
#pragma warning disable 1998
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The currently running game engine instance.</param>
        public override async Task ExecuteAsync(GameEngine executingContext) {
            executingContext.Stop();
        }
#pragma warning restore 1998
        #endregion
    }
}

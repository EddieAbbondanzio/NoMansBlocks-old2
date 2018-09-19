using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Base class for commands to derive from.
    /// </summary>
    public abstract class Command {
        #region Properties
        /// <summary>
        /// The category the command belongs to.
        /// </summary>
        public abstract CommandType CommandType { get; }

        /// <summary>
        /// The permissions required to call the command.
        /// </summary>
        public abstract PermissionLevel RequiredPermissions { get; }

        public DateTime Time { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new command with a time of now.
        /// </summary>
        public Command() {
            Time = DateTime.Now;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command on the current game
        /// engine.
        /// </summary>
        /// <param name="executingContext">The running game engine.</param>
        public abstract void Execute(GameEngine executingContext);

        /// <summary>
        /// Summarize the command in a print
        /// friendly string.
        /// </summary>
        /// <returns>The command as a string.</returns>
        public abstract string Summarize();
        #endregion
    }
}

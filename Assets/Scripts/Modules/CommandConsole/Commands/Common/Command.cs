using NoMansBlocks;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Base class for commands to derive from. This is for system commands
    /// and not the same as user commands.
    /// </summary>
    public abstract class Command {
        #region Properties
        /// <summary>
        /// The keyword that comes after the '/'.
        /// </summary>
        public abstract string Keyword { get; }
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command on the current game engine. This is
        /// async since a lot of the code base is also async.
        /// </summary>
        /// <param name="executingContext">The running game engine.</param>
        public abstract Task ExecuteAsync(GameEngine executingContext);

        /// <summary>
        /// Process the command parameters that were passed in when creating
        /// the command.
        /// </summary>
        /// <param name="parameters">The parameters split by spaces</param>
        public virtual void ParseParameters(string[] parameters) {
        }

        /// <summary>
        /// Summarize the command in a print
        /// friendly string.
        /// </summary>
        /// <returns>The command as a string.</returns>
        public override string ToString() {
            return string.Format("/{0}", Keyword);
        }
        #endregion
    }
}

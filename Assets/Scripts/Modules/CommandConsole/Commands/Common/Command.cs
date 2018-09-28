using NoMansBlocks;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.UserSystem;
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
        /// The keyword that comes after the '/'.
        /// </summary>
        public abstract string Keyword { get; }

        /// <summary>
        /// The permissions required to call the command.
        /// </summary>
        public abstract PermissionLevel RequiredPermissions { get; }

        /// <summary>
        /// The help tip to display in the HelpCommand.
        /// </summary>
        public abstract string HelpTip { get; }
        #endregion

        #region Publics
        /// <summary>
        /// Checks if the passed in permissions level is high enough
        /// to execute the command.
        /// </summary>
        /// <param name="permissionLevel">True if the user has permissions.</param>
        /// <returns>True if the passed in permissions are valid.</returns>
        public bool HasPermissions(PermissionLevel permissionLevel) {
            return (RequiredPermissions & permissionLevel) > 0;
        }

        /// <summary>
        /// Execute the command on the current game
        /// engine.
        /// </summary>
        /// <param name="executingContext">The running game engine.</param>
        public abstract void Execute(GameEngine executingContext);

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

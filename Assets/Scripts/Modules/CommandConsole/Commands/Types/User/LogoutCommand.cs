using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Log out the user that is currently logged in.
    /// </summary>
    public sealed class LogoutCommand : Command {
        #region Properties
        /// <summary>
        /// The keyword that comes after the '/'
        /// </summary>
        public override string Keyword => "login";

        /// <summary>
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.All;

        /// <summary>
        /// The help tip to show for the help command.
        /// </summary>
        public override string HelpTip => "Login to a user account. Expects a parameter of username followed by password, or a JWT";
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The game engine instance.</param>
        public override async void Execute(GameEngine executingContext) {
            if(User.Current != null) {
                await User.Current.LogoutAsync();
            }
        }

        /// <summary>
        /// The command as a print friendly string.
        /// </summary>
        /// <returns>The string of the command.</returns>
        public override string ToString() {
            return string.Format("/{0}", Keyword);
        }
        #endregion
    }
}

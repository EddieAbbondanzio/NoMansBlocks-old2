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
        public override string Keyword => "logout";
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The game engine instance.</param>
        /// <returns>True if no errors.</returns>
        public override async Task<bool> ExecuteAsync(GameEngine executingContext) {
            if(User.Current != null) {
                return await User.Current.LogoutAsync();
            }
            
            return false;
        }
        #endregion
    }
}

using NoMansBlocks.Core.Engine;
using NoMansBlocks.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Command to log in a user with the passed in credentials.
    /// </summary>
    public sealed class LoginCommand : Command {
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

        /// <summary>
        /// The username passed in.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password passed in.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The JWT passed in.
        /// </summary>
        public string LoginToken { get; set; }
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The game engine instance.</param>
        public override void Execute(GameEngine executingContext) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process the inputs the command.
        /// </summary>
        /// <param name="parameters">The list of parameters to process.</param>
        public override void ParseParameters(string[] parameters) {
            switch (parameters.Length) {
                case 1:
                    LoginToken = parameters[0];
                    break;
                case 2:
                    Username = parameters[0];
                    Password = parameters[1];
                    break;
            }
        }

        /// <summary>
        /// The command as a print friendly string.
        /// </summary>
        /// <returns>The string of the command.</returns>
        public override string ToString() {
            if(LoginToken != null) {
                return string.Format("/{0} ***********", Keyword);
            }
            else {
                return string.Format("/{0} {1} ********", Keyword, Username);
            }
        }
        #endregion
    }
}

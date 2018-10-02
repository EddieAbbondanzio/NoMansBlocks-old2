using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UserSystem;
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

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the login command that uses 
        /// standard credentials to attempt to log a user in.
        /// </summary>
        /// <param name="username">The username to log in under.</param>
        /// <param name="password">The password to authenticate.</param>
        public LoginCommand(string username, string password) {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Create a new login command that uses a login token
        /// from a previous login to log in the user.
        /// </summary>
        /// <param name="loginToken">The JWT to use.</param>
        public LoginCommand(string loginToken) {
            LoginToken = loginToken;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The game engine instance.</param>
        public override async Task ExecuteAsync(GameEngine executingContext) {
            if(LoginToken != null) {
                await User.LoginUserAsync(LoginToken);
            }
            else {
                await User.LoginUserAsync(Username, Password);
            }
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

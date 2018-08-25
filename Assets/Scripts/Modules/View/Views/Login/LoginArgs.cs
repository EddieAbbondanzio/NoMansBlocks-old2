using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// Arguments for passing login credentials
    /// around via events.
    /// </summary>
    public class LoginArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The username being logged in under.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// The password to authenticate with.
        /// </summary>
        public string Password { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create new login arguments to pass via an event.
        /// </summary>
        /// <param name="username">The username to log in under.</param>
        /// <param name="password">The password to use.</param>
        public LoginArgs(string username, string password) {
            Username = username;
            Password = password;
        }
        #endregion
    }
}

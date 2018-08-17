using NoMansBlocks.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Services {
    /// <summary>
    /// Handles providing users from the server.
    /// </summary>
    public class UserService {
        #region Publics
        /// <summary>
        /// Login to a user account by firing off a request to
        /// the account server.
        /// </summary>
        /// <param name="username">The username to use.</param>
        /// <param name="password">The password to use.</param>
        /// <returns></returns>
        public User LoginUser(string username, string password) {
            return null;
        }

        /// <summary>
        /// Register a new user with the server. This will send
        /// off the request to the server and if everything is good
        /// true will be returned. The user will have to validate their
        /// email before their account is active.
        /// </summary>
        /// <param name="username">Their desired username.</param>
        /// <param name="password">The password they want to use.</param>
        /// <param name="name">Their actual name.</param>
        /// <param name="email">Their email.</param>
        /// <returns>True if everything completed with no issue.</returns>
        public bool RegisterUser(string username, string password, string name, string email) {
            return false;
        }

        /// <summary>
        /// Checks if a username is available for use.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if the username is free for use.</returns>
        public bool IsUsernameAvailable(string username) {
            return false;
        }
        #endregion
    }
}

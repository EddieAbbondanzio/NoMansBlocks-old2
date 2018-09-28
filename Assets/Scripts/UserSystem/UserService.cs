using NoMansBlocks.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.UserSystem {
    /// <summary>
    /// Services related to Users such as logging in, or getting
    /// information about them.
    /// </summary>
    public static class UserService {
        #region Constants
        /// <summary>
        /// If the service should bother to actually authenticate
        /// users, or just run in debug mode.
        /// </summary>
        private const bool DebugMode = true;
        #endregion

        #region Publics
        /// <summary>
        /// Attempt to log in a user using the passed in credentials.
        /// </summary>
        /// <param name="username">The username to log in under.</param>
        /// <param name="password">The password to authenticate.</param>
        /// <returns>The user found (if any).</returns>
        public static User LoginUser(string username, string password) {
            if (DebugMode) {
                Log.Warn("User Service is running in DEBUG. No authentication performed.");
                return new User(username);
            }

            throw new NotImplementedException();
        }
        #endregion
    }
}

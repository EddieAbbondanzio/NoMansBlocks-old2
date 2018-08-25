﻿using NoMansBlocks.Core.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.UserSystem {
    /// <summary>
    /// Services related to Users such as logging in, or getting
    /// information about them.
    /// </summary>
    public static class UserService {
        #region Publics
        /// <summary>
        /// Attempt to log in a user using the passed in credentials.
        /// </summary>
        /// <param name="username">The username to log in under.</param>
        /// <param name="password">The password to authenticate.</param>
        /// <returns>The user found (if any).</returns>
        public static User LoginUser(string username, string password) {
            Log.Debug("User Service running in debug mode. No credential authentication.");
            return new User(username);
        }
        #endregion
    }
}

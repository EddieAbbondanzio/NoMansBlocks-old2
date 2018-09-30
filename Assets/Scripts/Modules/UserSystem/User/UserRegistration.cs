using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.UserSystem {
    /// <summary>
    /// Informaton of a user that wants to register a new
    /// account with the game.
    /// </summary>
    public sealed class UserRegistration {
        #region Properties
        /// <summary>
        /// The username that the user wants to use.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password they want to use to login with.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Their full name. Real or fake, who knows.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email to send a confirmation to.
        /// </summary>
        public string Email { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty user registration.
        /// </summary>
        public UserRegistration() {
        }

        /// <summary>
        /// Create a new fully populated user registration.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="name">The real name.</param>
        /// <param name="email">The contact email.</param>
        public UserRegistration(string username, string password, string name, string email) {
            Username = username;
            Password = password;
            Name  = name;
            Email = email;
        }
        #endregion
    }
}

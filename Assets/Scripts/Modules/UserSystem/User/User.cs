using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.UserSystem {
    /// <summary>
    /// Player Account for a user. This stores some info such
    /// as their username, real name, etc..
    /// </summary>
    public class User {
        #region Statics Properties
        /// <summary>
        /// The user running the game.
        /// </summary>
        public static User Current { get; set; }
        #endregion

        #region Properties
        /// <summary>
        /// The current login associated with the user.
        /// </summary>
        public UserLogin Login { get; set; }

        /// <summary>
        /// The unique id of the user.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's actual name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The email address tied to the account.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// The permissions level of the user.
        /// </summary>
        public PermissionLevel PermissionLevel { get; private set; }
        #endregion

        #region Events
        /// <summary>
        /// Fired off when a user logs in to their account.
        /// </summary>
        public static event EventHandler OnLogin;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new player with just a username.
        /// </summary>
        /// <param name="username"></param>
        public User(string username) {
            Username = username;
        }

        /// <summary>
        /// Create a new player with a username and custom
        /// permission level.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="permissionLevel">The permissions of the user.</param>
        public User(string username, PermissionLevel permissionLevel) {
            Username = username;
            PermissionLevel = permissionLevel;
        }
        #endregion

        #region Statics
        public static void SetUserService(IUserService userService) {
            throw new NotImplementedException();
        }

        public static User LoginUser(string username, string password) {
            throw new NotImplementedException();
        }

        public static User LoginUser(string token) {
            throw new NotImplementedException();
        }
        #endregion
    }
}

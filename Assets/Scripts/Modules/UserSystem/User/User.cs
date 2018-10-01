using NoMansBlocks.Modules.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UserSystem {
    /// <summary>
    /// Player Account for a user. This stores some info such
    /// as their username, real name, etc..
    /// </summary>
    public class User {
        #region Statics Properties
        /// <summary>
        /// The user running the game.
        /// </summary>
        public static User Current { get; private set; }

        /// <summary>
        /// The user service to communicate with the
        /// master server through.
        /// </summary>
        private static IUserService UserService { get; set; }
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
        public static event EventHandler<UserEventArgs> OnLogin {
            add { UserService.OnUserLogin += value; }
            remove { UserService.OnUserLogin -= value; }
        }
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

        #region Publics
        /// <summary>
        /// Log out the user. This will reach out to the master
        /// server and invalidate their current login.
        /// </summary>
        /// <returns>True if it completed no issue.</returns>
        public async Task<bool> LogoutAsync() {
            return await UserService.LogoutAsync(Username, Login.Guid);
        }

        /// <summary>
        /// Update a users current password. This will check
        /// that the current one is valid first.
        /// </summary>
        /// <param name="currentPassword">The user's current password.</param>
        /// <param name="newPassword">The user's new password.</param>
        /// <returns>True if no errors.</returns>
        public async Task<bool> UpdatePasswordAsync(string currentPassword, string newPassword) {
            return await UserService.UpdatePasswordAsync(Username, currentPassword, newPassword);
        }
        #endregion

        #region Statics
        /// <summary>
        /// Set the reference to the user service
        /// </summary>
        /// <param name="userService">The user service to use.</param>
        public static void SetUserService(IUserService userService) {
            UserService = userService;
        }

        /// <summary>
        /// Log in a user into an existing account via the credentials
        /// passed in. Once logged in the user can be retrieved
        /// via User.Current.
        /// </summary>
        /// <param name="username">The username to log in under.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>The logged in user. Or null if failed.</returns>
        public static async Task<User> LoginUserAsync(string username, string password) {
            if (Current != null) {
                throw new InvalidOperationException("Log out the current user first!");
            }

            Current = await UserService.LoginAsync(username, password);
            return Current;
        }

        /// <summary>
        /// Log in a user that has already logged in previously
        /// by using the login token they were granted. Once logged in
        /// the user can be retrieved via User.Current.
        /// </summary>
        /// <param name="token">The JWT to use.</param>
        /// <returns>The logged in user. Or null if failed.</returns>
        public static async Task<User> LoginUserAsync(string token) {
            if(Current != null) {
                throw new InvalidOperationException("Log out the current user first!");
            }

            Current = await UserService.LoginAsync(token);
            return Current;
        }

        /// <summary>
        /// Register a new user with the account server.
        /// </summary>
        /// <param name="registration">The new user's info.</param>
        /// <returns>True if no errors.</returns>
        public static async Task<bool> RegisterUserAsync(UserRegistration registration) {
            return await UserService.RegisterAsync(registration);
        }

        /// <summary>
        /// User forgot their username. This will send them an
        /// email with their username.
        /// </summary>
        /// <param name="email">The email to send to.</param>
        public static async Task ForgotUsernameAsync(string email) {
            await UserService.ForgotUsernameAsync(email);
        }

        /// <summary>
        /// User forgot their password. Send them an email with
        /// a verification token.
        /// </summary>
        /// <param name="username">The username of the user to reset.</param>
        public static async Task ForgotPasswordAsync(string username) {
            await UserService.ForgotPasswordAsync(username);
        }

        /// <summary>
        /// Reset the password using the verification token that
        /// was sent to their email.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <param name="verificationToken">The verification token to validate.</param>
        /// <param name="newPassword">Their new desired password.</param>
        /// <returns>True if the password successfully updated.</returns>
        public static async Task<bool> ResetPasswordAsync(string username, string verificationToken, string newPassword) {
            return await UserService.ResetPasswordAsync(username, verificationToken, newPassword);
        }

        /// <summary>
        /// Checks if the username passed in is free for the taking.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if it is available.</returns>
        public static async Task<bool> IsUsernameAvailable(string username) {
            return await UserService.IsUsernameAvailable(username);
        }
        #endregion
    }
}

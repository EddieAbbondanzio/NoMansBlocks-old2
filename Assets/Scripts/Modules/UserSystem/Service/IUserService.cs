using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UserSystem {
    /// <summary>
    /// Interface for the master server to implement. This is what the
    /// game expects from the account server.
    /// </summary>
    public interface IUserService : IService {
        #region Events
        /// <summary>
        /// Fired off when a user logs in.
        /// </summary>
        event EventHandler<UserEventArgs> OnUserLogin;
        #endregion

        #region Publics
        /// <summary>
        /// Login a user using the passed in credentials. This is
        /// rate limited.
        /// </summary>
        /// <param name="username">The username to log in under.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>The user if valid.</returns>
        Task<User> LoginAsync(string username, string password);

        /// <summary>
        /// Re login a user that has already logged in previously.
        /// This is rate limited.
        /// </summary>
        /// <param name="token">The JWT the server gave them last time.</param>
        /// <returns>The user if valid.</returns>
        Task<User> LoginAsync(string token);

        /// <summary>
        /// Logout a user that is currently logged in.
        /// </summary>
        /// <param name="username">The username to log out.</param>
        /// <param name="loginGuid">Their login GUID.</param>
        /// <returns>True if completed with no errors.</returns>
        Task<bool> LogoutAsync(string username, string loginGuid);

        /// <summary>
        /// Register a new user with the account server.
        /// </summary>
        /// <param name="registration">The new user's info.</param>
        /// <returns>True if no errors.</returns>
        Task<bool> RegisterAsync(UserRegistration registration);

        /// <summary>
        /// Reset the password using the verification token that
        /// was sent to their email.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <param name="verificationToken">The verification token to validate.</param>
        /// <param name="newPassword">Their new desired password.</param>
        /// <returns>True if the password successfully updated.</returns>
        Task<bool> ResetPasswordAsync(string username, string verificationToken, string newPassword);

        /// <summary>
        /// Update the current password by first validating their existing password.
        /// This will only work if the current password is correct.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <param name="currentPassword">Their current password.</param>
        /// <param name="newPassword">Their new password.</param>
        /// <returns>True if no error.</returns>
        Task<bool> UpdatePasswordAsync(string username, string currentPassword, string newPassword);

        /// <summary>
        /// User forgot their username. This will send them an
        /// email with their username.
        /// </summary>
        /// <param name="email">The user's email to look for.</param>
        Task ForgotUsernameAsync(string email);

        /// <summary>
        /// Send a request for the user's password to be reset.
        /// This will send an email with the verification code
        /// to be used.
        /// </summary>
        /// <param name="username">The name of the user to reset.</param>
        Task ForgotPasswordAsync(string username);

        /// <summary>
        /// Validate the login guid and username of a user that wants
        /// to connect to a game server.
        /// </summary>
        /// <param name="username">The username to look for.</param>
        /// <param name="loginGuid">Their login guid.</param>
        /// <returns>Their unique user id, or -1 if invalid.</returns>
        Task<long> ValidateUserAsync(string username, string loginGuid);

        /// <summary>
        /// Checks if the desired username is available.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if the username is valid.</returns>
        Task<bool> IsUsernameAvailable(string username);
        #endregion
    }
}

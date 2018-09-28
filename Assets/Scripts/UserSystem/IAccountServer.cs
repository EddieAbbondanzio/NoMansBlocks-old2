using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.UserSystem {
    /// <summary>
    /// Interface for the master server to implement. This is what the
    /// game expects from the account server.
    /// </summary>
    public interface IAccountServer {
        #region Publics
        /// <summary>
        /// Login a user using the passed in credentials.
        /// </summary>
        /// <param name="username">The username to log in under.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>The user if valid.</returns>
        Task<User> LoginAsync(string username, string password);

        /// <summary>
        /// Re login a user that has already logged in previously.
        /// </summary>
        /// <param name="token">The JWT the server gave them last time.</param>
        /// <returns>The user if valid.</returns>
        Task<User> RefreshLoginAsync(string token);

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
        /// Validate the login guid and username of a user that wants
        /// to connect to a game server.
        /// </summary>
        /// <param name="username">The username to look for.</param>
        /// <param name="loginGuid">Their login guid.</param>
        /// <returns>Their unique user id, or -1 if invalid.</returns>
        Task<long> ValidateLoginAsync(string username, string loginGuid);
        #endregion
    }
}

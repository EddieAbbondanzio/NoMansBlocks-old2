using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UserSystem {
    /// <summary>
    /// Services related to Users such as logging in, or getting
    /// information about them.
    /// </summary>
    public sealed class UserService : IUserService {
        public event EventHandler<UserEventArgs> OnUserLogin;

        public Task ForgotPasswordAsync(string username) {
            throw new NotImplementedException();
        }

        public Task ForgotUsernameAsync(string email) {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameAvailable(string username) {
            throw new NotImplementedException();
        }
        #region Publics
        public Task<User> LoginAsync(string username, string password) {
            throw new NotImplementedException();
        }

        public Task<User> LoginAsync(string token) {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutAsync(string username, string loginGuid) {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(UserRegistration registration) {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(string username, string verificationToken, string newPassword) {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(string username, string currentPassword, string newPassword) {
            throw new NotImplementedException();
        }

        public Task<long> ValidateUserAsync(string username, string loginGuid) {
            throw new NotImplementedException();
        }


        Task<User> IUserService.LoginAsync(string username, string password) {
            throw new NotImplementedException();
        }

        Task<User> IUserService.LoginAsync(string token) {
            throw new NotImplementedException();
        }
        #endregion
    }
}

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
    public sealed class UserService : IUserService {
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

        public Task<long> ValidateUserAsync(string username, string loginGuid) {
            throw new NotImplementedException();
        }
        #endregion
    }
}

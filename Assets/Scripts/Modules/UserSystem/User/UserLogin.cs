using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UserSystem {
    /// <summary>
    /// A user login contains
    /// </summary>
    public sealed class UserLogin {
        #region Properties
        /// <summary>
        /// The JWT associated with the login. This
        /// will be saved for future logins.
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// The unique guid of the user's login.
        /// </summary>
        public string Guid { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty UserLogin.
        /// </summary>
        public UserLogin() {
        }

        /// <summary>
        /// Create a new fully populated userlogin.
        /// </summary>
        /// <param name="token">The token to log in later with.</param>
        /// <param name="guid">The unique login GUID.</param>
        public UserLogin(string token, string guid) {
            Token = token;
            Guid  = guid;
        }
        #endregion
    }
}

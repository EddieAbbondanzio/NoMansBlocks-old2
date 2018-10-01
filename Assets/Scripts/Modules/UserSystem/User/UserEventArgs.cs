using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UserSystem {
    /// <summary>
    /// Event args for passing around a user object.
    /// </summary>
    public sealed class UserEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The user being passed around.
        /// </summary>
        public User User { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of user event args.
        /// </summary>
        /// <param name="user">The user.</param>
        public UserEventArgs(User user) {
            User = user;
        }
        #endregion
    }
}

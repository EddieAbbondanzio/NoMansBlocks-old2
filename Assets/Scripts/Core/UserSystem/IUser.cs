using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.UserSystem {
    /// <summary>
    /// Interface to represent both a guest, regular
    /// user, or server admin.
    /// </summary>
    public interface IUser {
        #region Properties
        /// <summary>
        /// The name to represent them as.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// The level of permissions the user has.
        /// </summary>
        PermissionLevel PermissionLevel { get; }
        #endregion
    }
}

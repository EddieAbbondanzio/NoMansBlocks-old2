﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.UserSystem {
    /// <summary>
    /// Player Account for a user. This stores some info such
    /// as their username, real name, etc..
    /// </summary>
    public class User : IUser {
        #region Properties
        /// <summary>
        /// The unique id of the user.
        /// </summary>
        public ulong Id { get; set; }

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

        #region Constructor(s)
        /// <summary>
        /// Create a new player with just a 
        /// </summary>
        /// <param name="username"></param>
        public User(string username) {
            Username = username;
        }
        #endregion
    }
}
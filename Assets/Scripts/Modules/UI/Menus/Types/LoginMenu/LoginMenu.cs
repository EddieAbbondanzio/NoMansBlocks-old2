using NoMansBlocks.Modules.UI.Controls;
using System;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// The client login menu. Attempts to get 
    /// Username + password from the client.
    /// </summary>
    [MenuPresenter(typeof(LoginMenuPresenter))]
    public sealed class LoginMenu : IMenu {
        #region Properties
        /// <summary>
        /// The username the user entered.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password the user entered.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// If the user wants to save their credentials.
        /// </summary>
        public bool RememberMe { get; set; }
        #endregion
    }
}
using NoMansBlocks.Modules.UI.Controls;
using System;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// The client login menu. Attempts to get 
    /// Username + password from the client.
    /// </summary>
    public sealed class LoginMenu : IMenu {
        #region Properties
        /// <summary>
        /// The type of presenter that can handle this menu model.
        /// </summary>
        public Type MenuPresenterType => typeof(LoginMenuPresenter);
        #endregion

    }
}
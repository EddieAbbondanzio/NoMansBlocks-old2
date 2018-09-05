using NoMansBlocks.Modules.UI.Controls;
using System;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// The client login menu. Attempts to get 
    /// Username + password from the client.
    /// </summary>
    [MenuPresenter(typeof(LoginMenuPresenter))]
    public sealed class LoginMenu : IMenu {

    }
}
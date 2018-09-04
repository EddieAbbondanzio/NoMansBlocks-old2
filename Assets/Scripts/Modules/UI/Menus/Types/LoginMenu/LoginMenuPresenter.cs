using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Presenter that handles loading and syncing up the login menu view with
    /// it's model counterpart.
    /// </summary>
    public sealed class LoginMenuPresenter : MenuPresenter {
        #region Properties
        /// <summary>
        /// The path where the view prefab resides.
        /// </summary>
        protected override string PrefabPath => "Menus/LoginView/LoginMenu";
        #endregion

        protected override void OnInput(IControlHandler control, InputActionType actionType) {
            Log.Debug("Control {0} was modified by {1}", control.Name, actionType.ToString());
        }
    }
}

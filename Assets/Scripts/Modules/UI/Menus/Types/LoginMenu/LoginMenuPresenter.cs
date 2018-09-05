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

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the login menu presenter. This should only
        /// be used within the UI module itself.
        /// </summary>
        /// <param name="menuController">The parent UI module</param>
        public LoginMenuPresenter(IMenuController menuController) : base(menuController) {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Checks if this menu presenter can load the menu passed in.
        /// </summary>
        /// <param name="model">The model to check.</param>
        /// <returns>True if it is on type login menu.</returns>
        public override bool IsSupportedModel(IMenu model) {
            return model.GetType() == typeof(LoginMenu);
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called each time a control in the menu view recieves some kind of
        /// input.
        /// </summary>
        /// <param name="control">The control that was modified.</param>
        /// <param name="actionType">The type of action performed on it.</param>
        protected override void OnInput(IControlHandler control, InputActionType actionType) {
            Log.Debug("Control {0} was modified by {1}", control.Name, actionType.ToString());
        }
        #endregion
    }
}

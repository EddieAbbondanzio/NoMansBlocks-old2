using NoMansBlocks.Modules.UI.Presenter;

namespace NoMansBlocks.Modules.UI.Model {
    /// <summary>
    /// The client login menu. Attempts to get 
    /// Username + password from the client.
    /// </summary>
    public sealed class LoginMenu : Menu {
        #region Properties
        /// <summary>
        /// The path where the prefab view can
        /// be found.
        /// </summary>
        protected override string PrefabPath => "Menus/LoginView/LoginMenu";
        #endregion

        #region Helpers
        /// <summary>
        /// Called each time a control has some kind of
        /// input from the user.
        /// </summary>
        /// <param name="control">The control that was modified</param>
        /// <param name="actionType">What kind of action was performed.</param>
        protected override void OnInput(IControlPresenter control, InputActionType actionType) {
            Log.Debug("Control {0} was modified by {1}", control.Name, actionType.ToString());
        }
        #endregion
    }
}
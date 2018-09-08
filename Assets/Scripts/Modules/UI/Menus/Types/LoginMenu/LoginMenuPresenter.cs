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
    public sealed class LoginMenuPresenter : MenuPresenter<LoginMenu> {
        #region Properties
        /// <summary>
        /// The path where the view prefab resides.
        /// </summary>
        protected override string PrefabPath => "Menus/LoginView/LoginMenu";
        #endregion

        #region Members 
        /// <summary>
        /// The textbox that users enter their username into.
        /// </summary>
        private ITextBoxHandler usernameTextBox;

        /// <summary>
        /// The textbox that users enter their password into
        /// </summary>
        private ITextBoxHandler passwordTextBox;

        /// <summary>
        /// The textbox that users tick if they want to remember
        /// their credentials for later on.
        /// </summary>
        private ICheckBoxHandler rememberMeCheckBox;

        /// <summary>
        /// The button the user presses to attempt to log in.
        /// </summary>
        private ITriggerButtonHandler loginButton;
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

        #region Life Cycle Events
        /// <summary>
        /// Anytime the menu view is loaded, find all the important views.
        /// </summary>
        protected override void OnLoad() {
            usernameTextBox    = controlCoordinator.GetControl<ITextBoxHandler>("UsernameField");
            passwordTextBox    = controlCoordinator.GetControl<ITextBoxHandler>("PasswordField");
            rememberMeCheckBox = controlCoordinator.GetControl<ICheckBoxHandler>("RememberToggle");
            loginButton        = controlCoordinator.GetControl<ITriggerButtonHandler>("LoginButton");

            loginButton.OnClick += LoginButton_OnClick;
        }

        /// <summary>
        /// Called when the view is being destroyed. Frees up resources and
        /// prevents memory leaks.
        /// </summary>
        protected override void OnUnload() {
            loginButton.OnClick -= LoginButton_OnClick;
        }

        /// <summary>
        /// Syncs up all the controls on the view with the current data in the model.
        /// </summary>
        protected override void OnDataBind() {
            usernameTextBox.Text         = Model.Username;
            passwordTextBox.Text         = Model.Password;
            rememberMeCheckBox.IsChecked = Model.RememberMe;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Fired when the user clicks the login button. They want to try to
        /// log in.
        /// </summary>
        private void LoginButton_OnClick(object sender, EventArgs e) {
            menuController.LoadMenu<MainMenu>();
        }
        #endregion
    }
}

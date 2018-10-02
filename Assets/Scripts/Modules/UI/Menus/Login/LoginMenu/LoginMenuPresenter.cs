using NoMansBlocks.Modules.CommandConsole;
using NoMansBlocks.Modules.CommandConsole.Commands;
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
        protected override string PrefabPath => "Menus/Login/LoginMenu";
        #endregion

        #region Members 
        /// <summary>
        /// The textbox that users enter their username into.
        /// </summary>
        private ITextBox usernameTextBox;

        /// <summary>
        /// The textbox that users enter their password into
        /// </summary>
        private ITextBox passwordTextBox;

        /// <summary>
        /// The textbox that users tick if they want to remember
        /// their credentials for later on.
        /// </summary>
        private ICheckBox rememberMeCheckBox;

        /// <summary>
        /// The button the user presses to attempt to log in.
        /// </summary>
        private ITriggerButton loginButton;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the login menu presenter. This should only
        /// be used within the UI module itself.
        /// </summary>
        /// <param name="uiModule">The parent UI module</param>
        /// <param name="commandConsole">The command console of the engine</param>
        public LoginMenuPresenter(IMenuManager uiModule, ICommandConsole commandConsole) : base(uiModule, commandConsole) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Anytime the menu view is loaded, find all the important views.
        /// </summary>
        protected override void OnLoad() {
            usernameTextBox    = GetControl<ITextBox>("UsernameField");
            passwordTextBox    = GetControl<ITextBox>("PasswordField");
            rememberMeCheckBox = GetControl<ICheckBox>("RememberToggle");
            loginButton        = GetControl<ITriggerButton>("LoginButton");

            loginButton.OnClick              += LoginButton_OnClick;
            rememberMeCheckBox.OnCheckChange += RememberMeCheckBox_OnCheckChange;
            usernameTextBox.OnBlur           += UsernameTextBox_OnBlur;
            passwordTextBox.OnBlur           += PasswordTextBox_OnBlur;

            //TODO:
            //Need to get the login config and see if we have a 
        }

        /// <summary>
        /// Called when the view is being destroyed. Frees up resources and
        /// prevents memory leaks.
        /// </summary>
        protected override void OnUnload() {
            loginButton.OnClick              -= LoginButton_OnClick;
            rememberMeCheckBox.OnCheckChange -= RememberMeCheckBox_OnCheckChange;
            usernameTextBox.OnBlur           -= UsernameTextBox_OnBlur;
            passwordTextBox.OnBlur           -= PasswordTextBox_OnBlur;
        }

        /// <summary>
        /// Syncs up all the controls on the view with the current data in the model.
        /// </summary>
        protected override void OnDataBind() {
            usernameTextBox.Text         = DataSource.Username;
            passwordTextBox.Text         = DataSource.Password;
            rememberMeCheckBox.IsChecked = DataSource.RememberMe;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Fired when the user clicks the login button. They want to try to
        /// log in.
        /// </summary>
        private async void LoginButton_OnClick(object sender, EventArgs e) {

            LoadMenu<MainMenu>();
        }

        /// <summary>
        /// Fired off when the checkbox is either checked, or unchecked.
        /// This takes the input from the presenter and updates the model.
        /// </summary>
        /// <param name="sender">The checkbox itself.</param>
        /// <param name="e">Event args.</param>
        private void RememberMeCheckBox_OnCheckChange(object sender, EventArgs e) {
            DataSource.RememberMe = rememberMeCheckBox.IsChecked;
        }

        /// <summary>
        /// Goes off when the username textbox is left. This ensures we keep the
        /// username up to date at any time.
        /// </summary>
        /// <param name="sender">The textbox itself.</param>
        /// <param name="e">Event args.</param>
        private void UsernameTextBox_OnBlur(object sender, EventArgs e) {
            DataSource.Username = usernameTextBox.Text;
        }

        /// <summary>
        /// Goes off when the password textbox is left. This ensures we
        /// keep an up to date version of the password on the model.
        /// </summary>
        /// <param name="sender">The textbox itself.</param>
        /// <param name="e">Event args.</param>
        private void PasswordTextBox_OnBlur(object sender, EventArgs e) {
            DataSource.Password = passwordTextBox.Text;
        }
        #endregion
    }
}

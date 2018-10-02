using NoMansBlocks.Modules.CommandConsole;
using NoMansBlocks.Modules.CommandConsole.Commands;
using NoMansBlocks.Modules.Config;
using NoMansBlocks.Modules.UI.Controls;
using NoMansBlocks.Modules.UserSystem;
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
        /// The config file for the login portion of the game.
        /// </summary>
        private LoginConfig loginConfig;

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
        /// <param name="configContainer">The config container for storing configs.</param>
        public LoginMenuPresenter(IMenuManager uiModule, ICommandConsole commandConsole, IConfigContainer configContainer) : base(uiModule, commandConsole, configContainer) {
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

            loginConfig = GetConfig<LoginConfig>();

            //Do we have values to populate?
            if (loginConfig.HasToken()) {
                Model.Username   = loginConfig.Username;
                Model.Password   = "hunter2";
                Model.RememberMe = true;
                Model.Token      = loginConfig.Token;
            }
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
        private async void LoginButton_OnClick(object sender, EventArgs e) {
            LoginCommand loginCommand;

            //Token? If so log in with it.
            if (!string.IsNullOrWhiteSpace(Model.Token)) {
                loginCommand = new LoginCommand(Model.Token);
            }
            else {
                loginCommand = new LoginCommand(Model.Username, Model.Password);
            }

            //Did the login command work?
            if(await ExecuteCommandAsync(loginCommand)) {
                //Do we need to save anything?
                if (Model.RememberMe) {
                    loginConfig.Username   = Model.Username;
                    loginConfig.Token      = User.Current.Login.Token;
                    loginConfig.RememberMe = true;
                }
                //Wipe out things
                else {
                    loginConfig.ResetToDefault();
                }

                LoadMenu<MainMenu>();
            }
        }

        /// <summary>
        /// Fired off when the checkbox is either checked, or unchecked.
        /// This takes the input from the presenter and updates the model.
        /// </summary>
        /// <param name="sender">The checkbox itself.</param>
        /// <param name="e">Event args.</param>
        private void RememberMeCheckBox_OnCheckChange(object sender, CheckBoxEventArgs e) {
            Model.RememberMe = rememberMeCheckBox.IsChecked;
        }

        /// <summary>
        /// Goes off when the username textbox is left. This ensures we keep the
        /// username up to date at any time.
        /// </summary>
        /// <param name="sender">The textbox itself.</param>
        /// <param name="e">Event args.</param>
        private void UsernameTextBox_OnBlur(object sender, EventArgs e) {
            //If things were modified, and we have a token. Null it!
            if (Model.Username != null && !Model.Username.Equals(usernameTextBox.Text) && Model.Token != null) {
                Model.Token = null;
            }

            Model.Username = usernameTextBox.Text;
        }

        /// <summary>
        /// Goes off when the password textbox is left. This ensures we
        /// keep an up to date version of the password on the model.
        /// </summary>
        /// <param name="sender">The textbox itself.</param>
        /// <param name="e">Event args.</param>
        private void PasswordTextBox_OnBlur(object sender, EventArgs e) {
            //If things were modified, and we have a token. Null it!
            if (Model.Password != null && !Model.Password.Equals(passwordTextBox.Text) && Model.Token != null) {
                Model.Token = null;
            }

            Model.Password = passwordTextBox.Text;
        }
        #endregion
    }
}

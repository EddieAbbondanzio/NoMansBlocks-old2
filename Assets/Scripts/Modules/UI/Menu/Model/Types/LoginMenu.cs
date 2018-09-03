//using NoMansBlocks.Modules.UI.Controls;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine.UI;

//namespace NoMansBlocks.Modules.UI {
//    /// <summary>
//    /// The menu responsible for getting user login
//    /// credentials from the user.
//    /// </summary>
//    public sealed class LoginMenu : Menu {
//        #region Properties
//        /// <summary>
//        /// The prefab name of the prefab to 
//        /// load for this menu.
//        /// </summary>
//        protected override string PrefabPath => "Menus/LoginView/LoginMenu";
//        #endregion

//        #region Members
//        /// <summary>
//        /// The button that the user presses when
//        /// they want to attempt to login.
//        /// </summary>
//        private TriggerButtonBehaviour loginButton;

//        /// <summary>
//        /// The text field for the user's username.
//        /// </summary>
//        private InputField usernameField;

//        /// <summary>
//        /// The text field for the user's password.
//        /// </summary>
//        private InputField passwordField;

//        /// <summary>
//        /// The toggle indicating if the user wants us to save
//        /// their credentials for later use.
//        /// </summary>
//        private Toggle rememberCredentialsToggle;
//        #endregion

//        #region Life Cycle Events
//        /// <summary>
//        /// Attempt to find all the important controls in the
//        /// menu.
//        /// </summary>
//        protected override void OnLoad() {
//            //loginButton = FindControl<ButtonPresenter>("LoginButton");

//            //usernameField = FindChildGameObject("UsernameField").GetComponent<InputField>();
//            //passwordField = FindChildGameObject("PasswordField").GetComponent<InputField>();
//            //rememberCredentialsToggle = FindChildGameObject("RememberToggle").GetComponent<Toggle>();

//            loginButton.OnClick += OnLoginClicked;
//        }

//        /// <summary>
//        /// Called as the menu instance is destroyed. Remove
//        /// any event listeners.
//        /// </summary>
//        protected override void OnDestroy() {
//            loginButton.OnClick -= OnLoginClicked;
//        }
//        #endregion

//        #region Helpers
//        /// <summary>
//        /// Fired everytime the login button is pressed. Attempt
//        /// to login the credentials passed in.
//        /// </summary>
//        private void OnLoginClicked(object sender, EventArgs e) {
//            string username = usernameField.text;
//            string password = passwordField.text;

          
//        }
//        #endregion
//    }
//}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// The menu that handles logging in Users and
    /// finding their user accounts from the master
    /// server.
    /// </summary>
    public class LoginMenu : Menu {
        #region Properties
        /// <summary>
        /// The prefab name of the prefab to 
        /// load for this menu.
        /// </summary>
        public override string Name => "LoginMenu";
        #endregion

        #region Members
        /// <summary>
        /// The button that the user presses when
        /// they want to attempt to login.
        /// </summary>
        private Button loginButton;

        /// <summary>
        /// The text field for the user's username.
        /// </summary>
        private InputField usernameField;

        /// <summary>
        /// The text field for the user's password.
        /// </summary>
        private InputField passwordField;

        /// <summary>
        /// The toggle indicating if the user wants us to save
        /// their credentials for later use.
        /// </summary>
        private Toggle rememberCredentialsToggle;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new login menu for the view passed in.
        /// </summary>
        /// <param name="view">The parent view.</param>
        public LoginMenu(GameView view) : base (view) {
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Attempt to find all the important controls in the
        /// menu.
        /// </summary>
        protected override void OnLoaded() {
            loginButton   = FindChildGameObject("LoginButton").GetComponent<Button>();
            usernameField = FindChildGameObject("UsernameField").GetComponent<InputField>();
            passwordField = FindChildGameObject("PasswordField").GetComponent<InputField>();
            rememberCredentialsToggle = FindChildGameObject("RememberToggle").GetComponent<Toggle>();

            loginButton.onClick.AddListener(OnLoginClicked);
        }

        /// <summary>
        /// Called as the menu instance is destroyed. Remove
        /// any event listeners.
        /// </summary>
        protected override void OnDestroyed() {
            loginButton.onClick.RemoveListener(OnLoginClicked);
        }

        /// <summary>
        /// Fired everytime the login button is pressed. Attempt
        /// to login the credentials passed in.
        /// </summary>
        private void OnLoginClicked() {
            string username = usernameField.text;
            string password = passwordField.text;

            Log.Debug("Logging in with credentials: {0} {1}", username, password);
        }
        #endregion
    }
}
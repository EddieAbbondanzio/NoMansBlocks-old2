using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using UnityEngine.SceneManagement;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// The login menu of the game. This is the first thing loaded.
    /// </summary>
    public class LoginView : GameView {
        #region Properties
        /// <summary>
        /// The unique name of the view. This should match up
        /// with the name of the Unity scene to use.
        /// </summary>
        public override string Name => "LoginView";

        /// <summary>
        /// Only the client can open the login view.
        /// </summary>
        public override EngineType Type => EngineType.Client;
        #endregion

        #region Members
        /// <summary>
        /// Reference to the login menu.
        /// </summary>
        private LoginMenu loginMenu;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new login view scene.
        /// </summary>
        public LoginView() : base() {
            loginMenu = new LoginMenu(this);
            Menus.Add(loginMenu);

            loginMenu.OnLoginSubmit += OnLoginSubmitted;
        }

        /// <summary>
        /// Prevent memory leaks.
        /// </summary>
        ~LoginView() {
            loginMenu.OnLoginSubmit -= OnLoginSubmitted;
        }
        #endregion

        #region Menu Events
        /// <summary>
        /// Fired everytime the user attempts to log in.
        /// </summary>
        /// <param name="sender">The login menu</param>
        /// <param name="e">Event args</param>
        private void OnLoginSubmitted(object sender, LoginArgs e) {
            //Attempt to log the user in.
            User user = User.Login(e.Username, e.Password);

            //If the user was good, load the main menu.
            if(user != null) {
                GameEngine.Instance.User = user;
                GameEngine.Instance.ViewModule.LoadView("MainView");
            }
            //Failed, show error.
            else {
                loginMenu.ShowErrorMessage();
            }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Whenever the view is first loaded, set up
        /// the login menu to be visible.
        /// </summary>
        protected override void OnLoad() {
            Menus[0].SetVisible();
        }
        #endregion
    }
}

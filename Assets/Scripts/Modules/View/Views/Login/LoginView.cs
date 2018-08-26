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
    public sealed class LoginView : GameView {
        #region Properties
        /// <summary>
        /// Only the client can open the login view.
        /// </summary>
        public override EngineType Type => EngineType.Client;

        /// <summary>
        /// The unique name of the view. This should match up
        /// with the name of the Unity scene to use.
        /// </summary>
        protected override string Name => "LoginView";

        /// <summary>
        /// The menu used to get username + password
        /// from the user.
        /// </summary>
        private LoginMenu LoginMenu { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new login view scene.
        /// <paramref name="viewModule">The module that owns this view<paramref name="viewModule"/>
        /// </summary>
        public LoginView(ViewModule viewModule) : base(viewModule) {
            LoginMenu = new LoginMenu(this);
            LoginMenu.OnLoginSubmit += OnLoginSubmitted;
        }

        /// <summary>
        /// Prevent memory leaks.
        /// </summary>
        ~LoginView() {
            LoginMenu.OnLoginSubmit -= OnLoginSubmitted;
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Whenever the view is first loaded, set up
        /// the login menu to be visible.
        /// </summary>
        protected override void OnLoad() {
            LoginMenu.SetVisible();
        }
        #endregion

        #region Input Events
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
                User.Current = user;
                LoadView<MainView>();
            }
            //Failed, show error.
            else {
                LoginMenu.ShowErrorMessage();
            }
        }
        #endregion
    }
}

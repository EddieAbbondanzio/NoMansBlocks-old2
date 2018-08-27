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
    /// The login menu of the client build. This is the first
    /// thing the client is presented with and won't allow them
    /// to proceed any further unless logged in.
    /// </summary>
    public sealed class LoginView : GameView {
        #region Properties
        /// <summary>
        /// The type of engine that can run this scene.
        /// A server build has no need for a login screen.
        /// </summary>
        public override GameEngineType Type => GameEngineType.Client;

        /// <summary>
        /// The unique name of the view. This should match up
        /// with the name of the Unity scene to use.
        /// </summary>
        public override string Name => "LoginView";

        /// <summary>
        /// The on screen controls used to obtain username
        /// and password from the player. This is loaded by 
        /// default.
        /// </summary>
        [DefaultMenu]
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
            else {
                LoginMenu.ShowErrorMessage();
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Core.Engine;
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
        public override string Name => "LoginScene";

        /// <summary>
        /// Only the client can open the login view.
        /// </summary>
        public override EngineType Type => EngineType.Client;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new login view scene.
        /// </summary>
        public LoginView() : base() {
            Menus.Add(new LoginMenu(this));
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Whenever the view is first loaded, set up
        /// the login menu to be visible.
        /// </summary>
        protected override void OnLoadComplete() {
            Menus[0].SetVisible();
        }
        #endregion
    }
}

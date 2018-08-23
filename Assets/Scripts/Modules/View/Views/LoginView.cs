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

        #region View Events
        /// <summary>
        /// Pulls in the Username, Password field so we
        /// can get user input from them.
        /// </summary>
        public override void OnLoad() {

        }
        #endregion
    }
}

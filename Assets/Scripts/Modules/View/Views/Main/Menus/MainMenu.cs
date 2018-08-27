using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// The main menu that's loaded right after
    /// the User logs in successfully.
    /// </summary>
    public sealed class MainMenu : GameMenu {
        #region Properties
        /// <summary>
        /// The path of where the prefab representing this
        /// menu resides.
        /// </summary>
        protected override string PrefabPath => "Menus/MainView/MainMenu";
        #endregion

        #region Members
        /// <summary>
        /// The 'Connect' to a lobby button.
        /// </summary>
        private Button connectButton;

        /// <summary>
        /// The 'Settings' button to open up the control
        /// manager and game settings.
        /// </summary>
        private Button settingsButton;

        /// <summary>
        /// The 'Exit' button to close out the game.
        /// </summary>
        private Button exitButton;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the main menu.
        /// </summary>
        /// <param name="view">The view that owns this menu.</param>
        public MainMenu(GameView view) : base(view) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Use this to locate all the desired controls
        /// from on screen.
        /// </summary>
        protected override void OnLoad() {
        }
        #endregion
    }
}

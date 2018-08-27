using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// The Main Menu of the game. This gives the players options such
    /// as to connect to a lobby, or enter settings, or quit.
    /// </summary>
    public class MainView : GameView {
        #region Properties
        /// <summary>
        /// The type of game engine that the main view
        /// can be loaded on. A server has no need for the
        /// main menu.
        /// </summary>
        public override GameEngineType Type => GameEngineType.Client;

        /// <summary>
        /// The unique name of the view. This should match up
        /// with the name of the Unity scene to use.
        /// </summary>
        public override string Name => "MainView";

        /// <summary>
        /// The main menu of the main view.
        /// </summary>
        [DefaultMenu]
        private MainMenu MainMenu { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new main menu view. This is a wrapper
        /// for working with Scenes.
        /// <paramref name="viewModule">The module that owns this view<paramref name="viewModule"/>
        /// </summary>
        public MainView(ViewModule viewModule) : base(viewModule) {
            MainMenu = new MainMenu(this);
        }
        #endregion
    }
}

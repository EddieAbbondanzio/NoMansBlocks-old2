using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// The main menu 'scene'. This allows the player to connect to 
    /// lobbys or adjust settings.
    /// </summary>
    public class MainView : GameView {
        #region Properties
        /// <summary>
        /// Only the client can open the login view.
        /// </summary>
        public override EngineType Type => EngineType.Client;

        /// <summary>
        /// The unique name of the view. This should match up
        /// with the name of the Unity scene to use.
        /// </summary>
        protected override string Name => "MainView";

        /// <summary>
        /// The main menu of the main view.
        /// </summary>
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

        #region Life Cycle Events
        /// <summary>
        /// When the view is loaded up, load up the main
        /// menu by default.
        /// </summary>
        protected override void OnLoad() {
            MainMenu.SetVisible();
        }
        #endregion
    }
}

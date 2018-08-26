using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the main menu.
        /// </summary>
        /// <param name="view">The view that owns this menu.</param>
        public MainMenu(GameView view) : base(view) {
        }
        #endregion
    }
}

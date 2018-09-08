using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Presenter that handles loading and syncing up the main menu view
    /// with it's model counterpart.
    /// </summary>
    public sealed class MainMenuPresenter : MenuPresenter<MainMenu> {
        #region Properties
        /// <summary>
        /// The path where the view prefab resides.
        /// </summary>
        protected override string PrefabPath => "Menus/MainView/MainMenu";
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the main menu presenter. This should
        /// only be called by the UI Module itself.
        /// </summary>
        /// <param name="menuController">The parent UI module.</param>
        public MainMenuPresenter(IMenuController menuController) : base (menuController) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Syncs up all the controls on the view with the current data in the model.
        /// </summary>
        protected override void OnDataBind() {
        }
        #endregion
    }
}

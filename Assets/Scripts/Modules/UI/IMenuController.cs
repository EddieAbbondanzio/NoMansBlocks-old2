using NoMansBlocks.Modules.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI {
    /// <summary>
    /// Interface to indicate that a module can handle loading, hiding,
    /// or unloading menus from the game.
    /// </summary>
    public interface IMenuController {
        #region Properties
        /// <summary>
        /// The currently active and visible menu on screen.
        /// This can be null if none are visible.
        /// </summary>
        IMenu ActiveMenu { get; }
        #endregion

        #region Publics
        /// <summary>
        /// Load a memory into memory by instantiating an instance of its 
        /// view and loading it with a default instance of it's menu model.
        /// </summary>
        /// <typeparam name="T">THe type of menu to load.</typeparam>
        /// <param name="activateOnLoad">If it should be made visible once loaded.</param>
        void LoadMenu<T>(bool activateOnLoad = false) where T : class, IMenu;

        /// <summary>
        /// Load a menu into memory by instantiating an instance of it's view
        /// and populating it with the data from the model passed in.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        /// <param name="menu">The menu's model.</param>
        /// <param name="activateOnLoad">If it should be made visible once loaded.</param>
        void LoadMenu<T>(T menu, bool activateOnLoad = false) where T : class, IMenu;

        /// <summary>
        /// Relase the resources of a loaded menu by deleting it
        /// from memory.
        /// </summary>
        /// <typeparam name="T">The type of menu to unload.</typeparam>
        void UnloadMenu<T>() where T : class, IMenu;

        /// <summary>
        /// Show an already loaded menu of type T
        /// on screen. This will hide any other currently
        /// visible menus.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        void ShowMenu<T>() where T : class, IMenu;

        /// <summary>
        /// Hide all menus in the scene so none are visible to
        /// the player. This retains them in memory however.
        /// </summary>
        void HideMenus();
        #endregion
    }
}

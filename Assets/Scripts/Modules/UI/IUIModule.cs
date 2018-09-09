using NoMansBlocks.Modules.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI {
    /// <summary>
    /// Barebones interface for interacting with the UIModule.
    /// </summary>
    public interface IUIModule {
        /// <summary>
        /// Load a memory into memory by instantiating an instance of its 
        /// view and loading it with a default instance of it's menu model.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        void LoadMenu<T>() where T : class, IMenu;

        /// <summary>
        /// Load a menu into memory by instantiating an instance of it's view
        /// and populating it with the data from the model passed in.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        /// <param name="menu">The menu's model.</param>
        void LoadMenu<T>(T menu) where T : class, IMenu;

        /// <summary>
        /// Relase the resources of a loaded menu by deleting it
        /// from memory.
        /// </summary>
        void UnloadMenu();
    }
}

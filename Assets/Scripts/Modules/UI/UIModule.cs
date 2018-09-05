using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoMansBlocks.Modules.UI {
    /// <summary>
    /// Module responsible for loading and handling
    /// user interfaces such as menus and more in game. This is
    /// the controller of menus
    /// </summary>
    public sealed class UIModule : Module, IMenuController {
        #region Constants
        /// <summary>
        /// The tag to look for in the scene to find the gameobject
        /// to attach menu instances to.
        /// </summary>
        private const string MenuContainerTag = "MenuContainer";
        #endregion

        #region Properties
        /// <summary>
        /// The currently active menu (if any).
        /// </summary>
        public IMenu ActiveMenu { get; private set; }

        #endregion

        #region Members
        /// <summary>
        /// The menu container that will hold every
        /// menu instnace.
        /// </summary>
        private Transform menuContainer;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the UI Module.
        /// </summary>
        /// <param name="engine">The engine that owns it.</param>
        public UIModule(GameEngine engine) : base(engine) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// When the module is first started see if 
        /// we can find our menu container in the scene.
        /// </summary>
        public override void OnInit() {
            menuContainer = GameObject.FindGameObjectWithTag(MenuContainerTag)?.transform;

            if (menuContainer == null) {
                throw new FormatException("Scene is poorly formatted. No menu container found.");
            }
        }

        /// <summary>
        /// Destroy any existing menus right before switching scenes.
        /// This will handle calling their release of resources.
        /// </summary>
        /// <param name="scene"></param>
        public override void OnSceneDestroyed(Scene scene) {
            //for (int i = 0; i < LoadedMenus.Count; i++) {
            //    LoadedMenus[i].Destroy();
            //}
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load a memory into memory by instantiating an instance of its 
        /// view and loading it with a default instance of it's menu model.
        /// </summary>
        /// <typeparam name="T">THe type of menu to load.</typeparam>
        /// <param name="activateOnLoad">If it should be made visible once loaded.</param>
        public void LoadMenu<T>(bool activateOnLoad) where T : class, IMenu {
            T menuInstance = Activator.CreateInstance(typeof(T)) as T;
            LoadMenu<T>(menuInstance, activateOnLoad);
        }

        /// <summary>
        /// Load a menu into memory by instantiating an instance of it's view
        /// and populating it with the data from the model passed in.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        /// <param name="menu">The menu's model.</param>
        /// <param name="activateOnLoad">If it should be made visible once loaded.</param>
        public void LoadMenu<T>(T menu, bool activateOnLoad) where T : class, IMenu {
            MenuPresenterAttribute presenterAttribute = typeof(T).GetCustomAttribute<MenuPresenterAttribute>();

            //Easy. We know what kind of presenter to use.
            if(presenterAttribute != null) {

            }
            //Need to brute force find one that can handle it.
            else {

            }
        }

        /// <summary>
        /// Relase the resources of a loaded menu by deleting it
        /// from memory.
        /// </summary>
        /// <typeparam name="T">The type of menu to unload.</typeparam>
        public void UnloadMenu<T>() where T : class, IMenu {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Show an already loaded menu of type T
        /// on screen. This will hide any other currently
        /// visible menus.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        public void ShowMenu<T>() where T : class, IMenu {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hide all menus in the scene so none are visible to
        /// the player. This retains them in memory however.
        /// </summary>
        public void HideMenus() {
            throw new NotImplementedException();
        }
        #endregion
    }
}

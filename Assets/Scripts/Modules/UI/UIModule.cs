using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public sealed class UIModule : Module {
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
        /// The list of found menu presenters being used to run
        /// menus.
        /// </summary>
        private List<MenuPresenter> loadedPresenters;

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
            loadedPresenters = new List<MenuPresenter>();
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
        /// Load a menu using it's default values. 
        /// </summary>
        /// <typeparam name="T">The type of menu to load</typeparam>
        /// <param name="showOnLoad">If it should be made visible upon load.</param>
        public void LoadMenu<T>(bool showOnLoad = false) where T : class, IMenu {
            T newInstance = Activator.CreateInstance(typeof(T)) as T;
            LoadMenu(newInstance, showOnLoad);
        }

        /// <summary>
        /// Load a menu with custom values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T">The type of menu to load</typeparam>
        /// <param name="showOnLoad">If it should be made visible upon load.</param>
        public void LoadMenu<T>(T menu, bool showOnLoad = false) where T : class, IMenu {
            //Check that this menu isn't already present
            //if (LoadedMenus.Any(m => m.GetType() == typeof(T))) {
            //    throw new Exception(string.Format("A menu of type {0} has already been loaded.", typeof(T)));
            //}

            T newMenu = Activator.CreateInstance(typeof(T)) as T;
            //newMenu.Load(MenuContainer);

            //LoadedMenus.Add(newMenu);
        }

        /// <summary>
        /// Release the resources of the menu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void UnloadMenu<T>() where T : IMenu {
            //for (int i = 0; i < LoadedMenus.Count; i++) {
            //    if (LoadedMenus[i].GetType() == typeof(T)) {
            //        LoadedMenus.RemoveAt(i);
            //    }
            //}
        }
        #endregion
    }
}

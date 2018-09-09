using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.CommandConsole;
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
    public sealed class UIModule : Core.Engine.Module, IUIModule {
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
        public IMenu ActiveMenu { get { return menuPresenter?.Model; } }
        #endregion

        #region Members
        /// <summary>
        /// The active presenter managing the 
        /// active menu. (If any).
        /// </summary>
        private IMenuPresenter menuPresenter;

        /// <summary>
        /// The menu container that will hold every
        /// menu instnace.
        /// </summary>
        private Transform menuContainer;

        /// <summary>
        /// Reference back to the command console.
        /// </summary>
        private ICommandConsole commandConsole;
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
            commandConsole = GetModule<CommandConsoleModule>();

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
            menuPresenter?.Unload();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load a memory into memory by instantiating an instance of its 
        /// view and loading it with a default instance of it's menu model.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        public void LoadMenu<T>() where T : class, IMenu {
            T menuInstance = Activator.CreateInstance(typeof(T)) as T;
            LoadMenu(menuInstance);
        }

        /// <summary>
        /// Load a menu into memory by instantiating an instance of it's view
        /// and populating it with the data from the model passed in.
        /// </summary>
        /// <typeparam name="T">The type of menu to load.</typeparam>
        /// <param name="menu">The menu's model.</param>
        public void LoadMenu<T>(T menu) where T : class, IMenu {
            if(menuPresenter != null) {
                menuPresenter.Unload();
            }

            MenuPresenterAttribute presenterAttribute = typeof(T).GetCustomAttribute<MenuPresenterAttribute>();

            //Easy. We know what kind of presenter to use.
            if (presenterAttribute != null) {
                //Is the current one what we need?
                if((menuPresenter?.GetType() ?? null) != presenterAttribute.Type) {
                    menuPresenter = Activator.CreateInstance(presenterAttribute.Type, this, commandConsole) as IMenuPresenter;
                }
            }
            else {
                throw new Exception(string.Format("No menu presenter attribute found on menu of type: {0}", typeof(T)));
            }

            menuPresenter.Load(menuContainer, menu);
        }

        /// <summary>
        /// Relase the resources of a loaded menu by deleting it
        /// from memory.
        /// </summary>
        public void UnloadMenu() {
            menuPresenter?.Unload();
        }
        #endregion
    }
}

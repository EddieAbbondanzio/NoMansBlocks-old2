using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// Represents a scene in Unity. Allows for some extra
    /// functionality on them.
    /// </summary>
    public abstract class GameView {
        #region Constants
        /// <summary>
        /// The tag on the menu container gameobject.
        /// </summary>
        private const string MenuContainerTag = "MenuContainer";
        #endregion

        #region Properties
        /// <summary>
        /// The engine instance that can run this scene.
        /// </summary>
        public abstract GameEngineType Type { get; }

        /// <summary>
        /// The name of the view, and scene in Unity.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The menu that is currently active in
        /// the scene. (if any).
        /// </summary>
        public GameMenu ActiveMenu { get; private set; }

        /// <summary>
        /// The menus of the scene.
        /// </summary>
        private List<GameMenu> Menus { get; set; }

        /// <summary>
        /// The module that owns the view.
        /// </summary>
        private ViewModule ViewModule { get; }
        #endregion

        #region Events
        /// <summary>
        /// Fired off when the view is loaded into the game.
        /// </summary>
        public event EventHandler<ViewLoadedArgs> OnLoaded;

        /// <summary>
        /// Fired off when the view is replaced by another.
        /// </summary>
        public event EventHandler OnDestroyed;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new gameview. This goes out and attempts to
        /// find the scene for the view.
        /// <paramref name="viewModule">The view module that owns the view.</paramref>
        /// </summary>
        protected GameView(ViewModule viewModule) {
            ViewModule = viewModule;

            //Validate that a scene exists for the name passed in.
            if (SceneManager.GetSceneByName(Name) == null) {
                throw new Exception(string.Format("Scene not found for view {0}", Name));
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load the resources needed by the view and
        /// get things ready for use.
        /// </summary>
        public void Load() {
            Transform menuContainer = FindMenuContainer(SceneManager.GetActiveScene());

            //Hunt down the menus
            PropertyInfo[] menuProperties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(p => p.PropertyType.IsSubclassOf(typeof(GameMenu))).ToArray();
            Menus = new List<GameMenu>();

            int defaultMenuIndex = -1;
            //Add them to the list of menus available.
            for (int i = 0; i < menuProperties.Length; i++) {
                Menus.Add(menuProperties[i].GetValue(this) as GameMenu);

                DefaultMenuAttribute defaultMenu = menuProperties[i].GetCustomAttribute<DefaultMenuAttribute>();
                if(defaultMenu != null) {
                    if(defaultMenuIndex != -1) {
                        throw new Exception("Two or more menus have been set as the default menu. This is not allowed.");
                    }

                    defaultMenuIndex = i;
                }
            }

            //Then we fire off the on load event
            if (OnLoaded != null) {
                OnLoaded(this, new ViewLoadedArgs(menuContainer));
            }

            if (defaultMenuIndex != -1) {
                Menus[defaultMenuIndex].SetVisible();
            }
        }

        /// <summary>
        /// Unallocate resources and finish things up. The
        /// view is no longer needed.
        /// </summary>
        public void Destroy() {
            if(OnDestroyed != null) {
                OnDestroyed(this, null);
            }
        }

        /// <summary>
        /// Get a menu using it's type. This is expensive, avoid 
        /// using it when possible.
        /// </summary>
        /// <typeparam name="T">The type of menu to hunt for.</typeparam>
        /// <returns>The menu found (if any).</returns>
        public GameMenu GetMenu<T>() where T : GameMenu {
            return Menus.Find(m => m.GetType() == typeof(T));
        }

        /// <summary>
        /// Checks if the view is currently active or not.
        /// </summary>
        /// <returns>True if this scene is in use.</returns>
        public bool IsActive() {
            return SceneManager.GetActiveScene().name == this.Name;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Load a view into use. This calls Destroy() on the current one,
        /// if there is one.
        /// </summary>
        /// <typeparam name="T">The type of view to load.</typeparam>
        protected void LoadView<T>() where T : GameView {
            ViewModule.LoadView<T>();
        }

        /// <summary>
        /// Searches for the menu container in the scene passed in.
        /// </summary>
        /// <param name="scene">The scene to look for the menu container
        /// object in.</param>
        /// <returns></returns>
        private static Transform FindMenuContainer(Scene scene) {
            GameObject[] rootObjects = scene.GetRootGameObjects();

            for(int i = 0; i < rootObjects.Length; i++) {
                if(rootObjects[i].tag == MenuContainerTag) {
                    return rootObjects[i].transform;
                }
            }

            throw new Exception(string.Format("Scene {0} was improperly set up. No gameobject with the tag 'MenuContainer' was found.", scene.name));
        }
        #endregion
    }
}

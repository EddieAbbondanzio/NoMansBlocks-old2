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
        /// The name of the view, and scene in Unity.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The engine instance that can run this scene.
        /// </summary>
        public abstract EngineType Type { get; }

        /// <summary>
        /// The menus available in this scene.
        /// </summary>
        public List<Menu> Menus { get; private set; }

        /// <summary>
        /// The menu that is currently active in
        /// the scene. (if any).
        /// </summary>
        public Menu VisibleMenu { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The Unity scene that this view represents.
        /// </summary>
        private readonly Scene scene;

        /// <summary>
        /// The gameobject that holds all of the menu prefabs
        /// for each menu in the view.
        /// </summary>
        private readonly Transform menuContainer;
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
        /// </summary>
        protected GameView() {
            Menus = new List<Menu>();
            scene = SceneManager.GetSceneByName(Name);
            menuContainer = FindMenuContainer(scene);

            if (scene == null) {
                throw new Exception(string.Format("Scene not found for view {0}", Name));
            }

            if(menuContainer == null) {
                throw new Exception("No menu container found!");
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load the resources needed by the view and
        /// get things ready for use.
        /// </summary>
        public void Load() {
            //Check that this scene isn't already loaded to prevent an infinite loop...
            if(SceneManager.GetActiveScene().name != Name) {
                SceneManager.LoadScene(scene.buildIndex);
            }

            //Then we fire off the on load event
            if (OnLoaded != null) {
                OnLoaded(this, new ViewLoadedArgs(menuContainer));
            }

            OnLoadComplete();
        }

        /// <summary>
        /// Unallocate resources and finish things up. The
        /// view is no longer needed.
        /// </summary>
        public void Destroy() {
            OnPreDestroy();

            if(OnDestroyed != null) {
                OnDestroyed(this, null);
            }
        }

        /// <summary>
        /// Load a menu of the view via it's unique
        /// identifier.
        /// </summary>
        /// <param name="menuName">The name of the menu to load.</param>
        public void SetMenuVisible(string menuName) {
            //Hide the previous menu
            VisibleMenu?.SetHidden();

            //Find the new one, and set it visible.
            VisibleMenu = Menus.Find(m => m.Name == menuName);
            VisibleMenu.SetVisible();
        }

        /// <summary>
        /// Hide all menus that are current active.
        /// </summary>
        public void HideMenus() {
            VisibleMenu?.SetHidden();
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Called after the view has been loaded into the game.
        /// This allows the view to do any custom work, such as 
        /// loading a specific menu.
        /// </summary>
        protected virtual void OnLoadComplete() {
        }

        /// <summary>
        /// Called right before the view is destroyed. This allows
        /// the view to get any info it wants before killing itself.
        /// </summary>
        protected virtual void OnPreDestroy() {
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

            return null;
        }
        #endregion
    }
}

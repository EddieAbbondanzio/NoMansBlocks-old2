using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// A menu represents, well a menu. This is useful for including
    /// more than one screen per view. Each menu should have it's own
    /// prefab that can quickly be loaded into use.
    /// </summary>
    public abstract class GameMenu {
        #region Properties
        /// <summary>
        /// The name of the menu. Used as a unique identifier.
        /// This should match up with the name of the prefab.
        /// </summary>
        protected abstract string PrefabPath { get; }

        /// <summary>
        /// The parent view that owns this menu.
        /// </summary>
        public GameView View { get; }

        /// <summary>
        /// The current state of the menu. If the menu is visible
        /// then this is set to active.
        /// </summary>
        public MenuState State { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The active instance of the menu
        /// gameobject.
        /// </summary>
        private GameObject instance;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new menu, and pass in it's parent view
        /// so we can subscribe to the view's lifecycle events.
        /// </summary>
        /// <param name="view">The parent view of the menu.</param>
        protected GameMenu(GameView view) {
            View = view;
            State = MenuState.Hidden;

            View.OnLoaded    += OnViewLoaded;
            View.OnDestroyed += OnViewDestroyed;
        }

        /// <summary>
        /// Destructor, handles preventing memory leaks.
        /// </summary>
        ~GameMenu() {
            View.OnLoaded    -= OnViewLoaded;
            View.OnDestroyed -= OnViewDestroyed;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Set the menu visible, so that it can be
        /// seen by the player.
        /// </summary>
        public void SetVisible() {
            instance.SetActive(true);
            State = MenuState.Visible;
        }

        /// <summary>
        /// Set the menu hidden, so that another menu
        /// can be visible.
        /// </summary>
        public void SetHidden() {
            instance.SetActive(false);
            State = MenuState.Hidden;
        }

        /// <summary>
        /// Search for a child gameobject of the menu.
        /// </summary>
        /// <param name="name">The name of the child
        /// to hunt for.</param>
        /// <returns>The found (if any) child matching the name passed in.</returns>
        public GameObject FindChildGameObject(string name) {
            if(instance != null) {
                Transform foundTrans = instance.transform.Find(name);

                if(foundTrans != null) {
                    return foundTrans.gameObject;
                }
            }

            return null;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Override this to do any extra work
        /// needed when the menu is being loaded.
        /// </summary>
        protected virtual void OnLoad() {
        }

        /// <summary>
        /// Override this to do any extra work needed
        /// when the menu is being destroyed.
        /// </summary>
        protected virtual void OnDestroy() {
        }

        /// <summary>
        /// Fired whenever the parent view is loaded.
        /// </summary>
        /// <param name="sender">The parent view.</param>
        /// <param name="e">Always null.</param>
        private void OnViewLoaded(object sender, ViewLoadedArgs e) {
            instance = FindOrInstantiateMenu(e.MenuContainer);
            OnLoad();
        }

        /// <summary>
        /// Fired whenever the parent view is destroyed.
        /// </summary>
        /// <param name="sender">The parent view.</param>
        /// <param name="e">Always null.</param>
        private void OnViewDestroyed(object sender, EventArgs e) {
            OnDestroy();
            GameObject.Destroy(instance);
            instance = null;
        }

        /// <summary>
        /// Search for the menu in the menucontainer, or load
        /// an new instance of it.
        /// </summary>
        /// <param name="menuContainer">The container holding all of the menus.</param>
        /// <returns>The newly created or found instance of the menu object.</returns>
        private GameObject FindOrInstantiateMenu(Transform menuContainer) {
            //See if the object already exists first.
            GameObject instance = menuContainer.Find(PrefabPath)?.gameObject;

            //Wasn't found, we need to load it.
            if (instance == null) {
                GameObject prefab = Resources.Load<GameObject>(PrefabPath);

                instance = GameObject.Instantiate(prefab);
                instance.transform.SetParent(menuContainer);

                //Reset the rect transform
                RectTransform menuTransform = instance.GetComponent<RectTransform>();
                menuTransform.localScale = new Vector3(1, 1, 1);
                menuTransform.offsetMin = new Vector2(0, 0);
                menuTransform.offsetMax = new Vector2(0, 0);
            }

            return instance;
        }
        #endregion
    }
}

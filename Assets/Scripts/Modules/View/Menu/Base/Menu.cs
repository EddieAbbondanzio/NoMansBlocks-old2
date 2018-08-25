using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// A menu represents, well a menu. This is useful for including
    /// more than one screen per view. Each menu should have it's own
    /// prefab that can quickly be loaded into use.
    /// </summary>
    public abstract class Menu {
        #region Constants
        /// <summary>
        /// The directory where menu prefabs are stored.
        /// </summary>
        public const string MenuDirectory = "Menus";
        #endregion

        #region Properties
        /// <summary>
        /// The name of the menu. Used as a unique identifier.
        /// This should match up with the name of the prefab.
        /// </summary>
        public abstract string Name { get; }

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
        /// The prefab of the menu
        /// </summary>
        private GameObject prefab;

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
        protected Menu(GameView view) {
            View = view;
            State = MenuState.Hidden;

            View.OnLoaded    += OnViewLoaded;
            View.OnDestroyed += OnViewDestroyed;
        }

        /// <summary>
        /// Destructor, handles preventing memory leaks.
        /// </summary>
        ~Menu() {
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
            prefab.SetActive(true);
            State = MenuState.Visible;

            OnVisible();
        }

        /// <summary>
        /// Set the menu hidden, so that another menu
        /// can be visible.
        /// </summary>
        public void SetHidden() {
            OnHidden();

            prefab.SetActive(false);
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
        /// when the menu is being set to visible.
        /// </summary>
        protected virtual void OnVisible() {
        }

        /// <summary>
        /// Override this to do any extra work
        /// when the menu is being set to hidden.
        /// </summary>
        protected virtual void OnHidden() {
        }

        /// <summary>
        /// Override this to do any extra work
        /// needed when the menu is being loaded.
        /// </summary>
        protected virtual void OnLoaded() {
        }

        /// <summary>
        /// Override this to do any extra work needed
        /// when the menu is being destroyed.
        /// </summary>
        protected virtual void OnDestroyed() {
        }

        /// <summary>
        /// Fired whenever the parent view is loaded.
        /// </summary>
        /// <param name="sender">The parent view.</param>
        /// <param name="e">Always null.</param>
        private void OnViewLoaded(object sender, ViewLoadedArgs e) {
            //See if the object already exists first.
            prefab = e.MenuContainer.Find(Name)?.gameObject;

            //Wasn't found, we need to load it.
            if(prefab == null) {
                string prefabPath = string.Format("{0}/{1}", MenuDirectory, Name);

                prefab = Resources.Load<GameObject>(prefabPath);

                instance = GameObject.Instantiate(prefab);
                instance.transform.SetParent(e.MenuContainer);

                //Reset the rect transform
                RectTransform menuTransform = instance.GetComponent<RectTransform>();
                menuTransform.localScale = new Vector3(1, 1, 1);
                menuTransform.offsetMin  = new Vector2(0, 0);
                menuTransform.offsetMax  = new Vector2(0, 0);
            }

            OnLoaded();
        }

        /// <summary>
        /// Fired whenever the parent view is destroyed.
        /// </summary>
        /// <param name="sender">The parent view.</param>
        /// <param name="e">Always null.</param>
        private void OnViewDestroyed(object sender, EventArgs e) {
            OnDestroyed();
            GameObject.Destroy(instance);
            instance = null;
        }
        #endregion
    }
}

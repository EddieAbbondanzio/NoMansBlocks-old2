using NoMansBlocks.Modules.UI.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.UI.Model {
    /// <summary>
    /// Base class for all menus to derive from.
    /// </summary>
    public abstract class Menu {
        #region Properties
        /// <summary>
        /// If the menu is currently
        /// </summary>
        public bool IsLoaded { get { return view != null; } }

        /// <summary>
        /// If the menu is currently active and visible on screen.
        /// </summary>
        public bool IsActive {
            get { return view?.activeSelf ?? false; }
            set { if (IsActive) { view.SetActive(value); } }
        }

        /// <summary>
        /// The path where the prefab for this menu 
        /// exists in the project directory.
        /// </summary>
        protected abstract string PrefabPath { get; }
        #endregion

        #region Members
        /// <summary>
        /// The presenter that handles interacting with
        /// the view for us.
        /// </summary>
        private MenuPresenter presenter;

        /// <summary>
        /// The spawned instance of the menu.
        /// </summary>
        private GameObject view;
        #endregion

        #region Publics
        /// <summary>
        /// Load this menu into memory and attach it as a child of
        /// the scene's menu container.
        /// </summary>
        /// <param name="menuContainer">The menu container holding all menus of the game.</param>
        public void Load(Transform menuContainer) {
            if (IsLoaded) {
                throw new InvalidOperationException("Menu is already loaded");
            }

            GameObject prefab = Resources.Load<GameObject>(PrefabPath);
            view = GameObject.Instantiate<GameObject>(prefab);
            view.transform.SetParent(menuContainer);

            //Reset the rect transform
            RectTransform menuTransform = view.GetComponent<RectTransform>();
            menuTransform.localScale = new Vector3(1, 1, 1);
            menuTransform.offsetMin  = new Vector2(0, 0);
            menuTransform.offsetMax  = new Vector2(0, 0);

            presenter = view.GetComponent<MenuPresenter>();

            if(presenter == null) {
                throw new FormatException(string.Format("Menu View {0} is missing it's presenter component.", PrefabPath));
            }

            presenter.OnInput += Presenter_OnInput;
            OnLoad();
        }


        /// <summary>
        /// Release the resources of the menu and destroy the gameobject.
        /// </summary>
        public void Destroy() {
            if (!IsLoaded) {
                throw new InvalidOperationException("Menu is not loaded! Cannot destroy.");
            }

            presenter.OnInput -= Presenter_OnInput;
            OnDestroy();
            GameObject.Destroy(view);
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called right after the menu has been loaded.
        /// Use this to initialize resources.
        /// </summary>
        protected virtual void OnLoad() {
        }

        /// <summary>
        /// Called right before the menu is destroyed.
        /// Use this to free up resources.
        /// </summary>
        protected virtual void OnDestroy() {
        }

        /// <summary>
        /// Fired off everytime a control on the menu view is acted upon.
        /// </summary>
        /// <param name="control">The control that was modified.</param>
        /// <param name="actionType">How it was modified.</param>
        protected virtual void OnInput(IControlPresenter control, InputActionType actionType) {
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Propogate the input event further to the model view itself.
        /// </summary>
        /// <param name="sender">The model presenter itself.</param>
        /// <param name="e">Details on the event.</param>
        private void Presenter_OnInput(object sender, InputEventArgs e) {
            OnInput(e.Control, e.ActionType);
        }
        #endregion
    }
}

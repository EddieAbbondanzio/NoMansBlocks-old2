using NoMansBlocks.Modules.UI.Controls;
using NoMansBlocks.Modules.UI.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Presenter for handling menu views and interacting with the
    /// menu models.
    /// </summary>
    public abstract class MenuPresenter<T> : IMenuPresenter where T : class, IMenu {
        #region Properties
        /// <summary>
        /// If the presenter currently has a menu loaded with an
        /// active view.
        /// </summary>
        public bool IsLoaded { get { return view != null; } }

        /// <summary>
        /// The menu model
        /// </summary>
        public T Model { get; set; }

        /// <summary>
        /// Underlying implementation to get the model
        /// when all that is available is an interface reference.
        /// </summary>
        IMenu IMenuPresenter.Model { get { return Model as IMenu; } }

        /// <summary>
        /// The resource path of where the prefab representing
        /// the menu view resides.
        /// </summary>
        protected abstract string PrefabPath { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new base instance of a menu presenter.
        /// </summary>
        /// <param name="menuController">The UI Module.</param>
        protected MenuPresenter(IMenuController menuController) {
            this.menuController = menuController;
        }
        #endregion

        #region Members
        /// <summary>
        /// The menu controller handling all menus in the game.
        /// This can be used to load other menus from this presenter.
        /// </summary>
        protected IMenuController menuController;

        /// <summary>
        /// The coordinator for finding controls in the view
        /// </summary>
        protected IInputControlCoordinator controlCoordinator;

        /// <summary>
        /// The view instance of the menu.
        /// </summary>
        private GameObject view;
        #endregion

        #region Publics
        /// <summary>
        /// Load this menu into memory and get an instance of the view
        /// instantiated.
        /// </summary>
        /// <param name="menuContainer">The container to attach the menu view to.</param>
        /// <param name="menu">The menu model to load.</param>
        public void Load(Transform menuContainer, T menu) {
            GameObject prefab = Resources.Load<GameObject>(PrefabPath);
            view = GameObject.Instantiate<GameObject>(prefab);
            view.transform.SetParent(menuContainer);

            //Reset the rect transform
            RectTransform menuTransform = view.GetComponent<RectTransform>();
            menuTransform.localScale = new Vector3(1, 1, 1);
            menuTransform.offsetMin = new Vector2(0, 0);
            menuTransform.offsetMax = new Vector2(0, 0);

            InputControlCoordinator inputCoordinator = view.GetComponent<InputControlCoordinator>();

            if(inputCoordinator == null) {
                throw new FormatException(string.Format("Menu view {0} is poorly formatted. No input control coordinator found.", PrefabPath));
            }

            inputCoordinator.OnInput += InputCoordinator_OnInput;
            controlCoordinator = inputCoordinator as IInputControlCoordinator;
            Model = menu;

            OnLoad();
            DataBind();
        }

        /// <summary>
        /// Load a model into use via this presenter.
        /// </summary>
        /// <param name="menuContainer">The container to put it in.</param>
        /// <param name="model">The model to load.</param>
        void IMenuPresenter.Load(Transform menuContainer, IMenu model) {
            T convertedModel = model as T;

            if(convertedModel != null) {
                Load(menuContainer, convertedModel);
            }
        }

        /// <summary>
        /// Release the resources of the menu and destroy the view
        /// currently loaded.
        /// </summary>
        public void Unload() {
            if (!IsLoaded) {
                throw new InvalidOperationException("Menu is not loaded! Cannot destroy.");
            }

            OnUnload();
            InputControlCoordinator inputCoordinator = view.GetComponent<InputControlCoordinator>();
            inputCoordinator.OnInput -= InputCoordinator_OnInput;
            GameObject.Destroy(view);
            Model = null;
        }

        /// <summary>
        /// Sync up view with the model by binding any important
        /// info from the model to the view.
        /// </summary>
        public void DataBind() {
            if(Model != null) {
                OnDataBind();
            }
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called right after the menu view is loaded. Use this
        /// to allocate any resources.
        /// </summary>
        protected virtual void OnLoad() {
        }

        /// <summary>
        /// Called right before the menu view is destroyed.
        /// Use this to free up any resources.
        /// </summary>
        protected virtual void OnUnload() {
        }

        /// <summary>
        /// Fired off everytime a control has some kind of input
        /// event acted upon it.
        /// </summary>
        /// <param name="control">The control that was modified.</param>
        /// <param name="action">The category of action performed.</param>
        protected virtual void OnInput(IControlHandler control, InputActionType action) {
        }

        /// <summary>
        /// Fired off everytime the presenter needs to update the view with
        /// the latest model info.
        /// </summary>
        protected abstract void OnDataBind();
        #endregion

        #region Helpers
        /// <summary>
        /// Propogate the input event further to the derived instance
        /// of this class.
        /// </summary>
        /// <param name="sender">The control coordinator.</param>
        /// <param name="e">Info about the event.</param>
        private void InputCoordinator_OnInput(object sender, InputEventArgs e) {
            OnInput(e.Control, e.ActionType);
        }
        #endregion
    }
}

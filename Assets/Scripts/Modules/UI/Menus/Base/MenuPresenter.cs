using NoMansBlocks.Modules.CommandConsole;
using NoMansBlocks.Modules.CommandConsole.Commands;
using NoMansBlocks.Modules.UI.Controls;
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
        public T DataSource { get; set; }

        /// <summary>
        /// Underlying implementation to get the model
        /// when all that is available is an interface reference.
        /// </summary>
        IMenu IMenuPresenter.Model { get { return DataSource as IMenu; } }

        /// <summary>
        /// The resource path of where the prefab representing
        /// the menu view resides.
        /// </summary>
        protected abstract string PrefabPath { get; }
        #endregion

        #region Members
        /// <summary>
        /// The controls found on the prefab of the menu model.
        /// </summary>
        private IControl[] controls;

        /// <summary>
        /// The menu controller handling all menus in the game.
        /// This can be used to load other menus from this presenter.
        /// </summary>
        private IMenuManager uiModule;

        /// <summary>
        /// The command console module for submitting commands though.
        /// </summary>
        private ICommandConsole commandConsole;

        /// <summary>
        /// The view instance of the menu.
        /// </summary>
        private GameObject view;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new base instance of a menu presenter.
        /// </summary>
        /// <param name="uiModule">The UI Module.</param>
        /// <param name="commandConsole">The command console of the engine</param>
        protected MenuPresenter(IMenuManager uiModule, ICommandConsole commandConsole) {
            this.uiModule = uiModule;
            this.commandConsole = commandConsole;
        }
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

            controls = view.GetComponentsInChildren<IControl>();
            DataSource = menu;

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
            GameObject.Destroy(view);
            controls = null;
            DataSource    = null;
        }

        /// <summary>
        /// Sync up view with the model by binding any important
        /// info from the model to the view.
        /// </summary>
        public void DataBind() {
            if(DataSource != null) {
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
        /// Fired off everytime the presenter needs to update the view with
        /// the latest model info.
        /// </summary>
        protected virtual void OnDataBind() {
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Parse and process a new command.
        /// </summary>
        /// <param name="command">The text of the command to parse.</param>
        protected async Task ExecuteCommandAsync(string command) {
            await commandConsole.ExecuteAsync(command);
        }

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected async Task ExecuteCommandAsync(Command command) {
            await commandConsole.ExecuteAsync(command);
        }

        /// <summary>
        /// Load a memory into memory by instantiating an instance of its 
        /// view and loading it with a default instance of it's menu model.
        /// </summary>
        /// <typeparam name="U">THe type of menu to load.</typeparam>
        protected void LoadMenu<U>() where U : class, IMenu {
            uiModule.LoadMenu<U>();
        }

        /// <summary>
        /// Load a menu into memory by instantiating an instance of it's view
        /// and populating it with the data from the model passed in.
        /// </summary>
        /// <typeparam name="U">The type of menu to load.</typeparam>
        /// <param name="menu">The menu's model.</param>
        protected void LoadMenu<U>(U menu) where U : class, IMenu {
            uiModule.LoadMenu<U>(menu);
        }

        /// <summary>
        /// Search for a specific control in the view.
        /// </summary>
        /// <typeparam name="U">The control type to look for.</typeparam>
        /// <param name="name">The name of the control</param>
        /// <returns>The control if found</returns>
        protected U GetControl<U>(string name) where U : class, IControl {
            for (int i = 0; i < controls.Length; i++) {
                if (typeof(U).IsAssignableFrom(controls[i].GetType()) && controls[i].Name == name) {
                    return controls[i] as U;
                }
            }

            return null;
        }

        /// <summary>
        /// Search for all controls of a specific type.
        /// </summary>
        /// <typeparam name="U">The type to hunt for.</typeparam>
        /// <returns>The controls of the matching type</returns>
        protected List<U> GetControls<U>() where U : class, IControl {
            List<U> matchingControls = new List<U>();

            for (int i = 0; i < controls.Length; i++) {
                if (typeof(U).IsAssignableFrom(controls[i].GetType())) {
                    matchingControls.Add(controls[i] as U);
                }
            }

            return matchingControls;
        }
        #endregion
    }
}

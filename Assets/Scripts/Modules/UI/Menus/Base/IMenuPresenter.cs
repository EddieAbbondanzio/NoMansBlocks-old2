using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Interface to allow for storing menu presenters in a list,
    /// or hold a generic reference to one, etc..
    /// </summary>
    public interface IMenuPresenter {
        #region Properties
        /// <summary>
        /// If the presenter currently has a menu loaded with an 
        /// active view.
        /// </summary>
        bool IsLoaded { get; }

        /// <summary>
        /// The currently active model. If any.
        /// </summary>
        IMenu Model { get; }
        #endregion

        #region Publics
        /// <summary>
        /// Load a model into use via this presenter.
        /// </summary>
        /// <param name="menuContainer">The container to put it in.</param>
        /// <param name="model">The model to load.</param>
        void Load(Transform menuContainer, IMenu model);

        /// <summary>
        /// Release the resources of the menu and destroy the view
        /// currently loaded.
        /// </summary>
        void Unload();

        /// <summary>
        /// Sync up view with the model by binding any important
        /// info from the model to the view.
        /// </summary>
        void DataBind();
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.UI {
    /// <summary>
    /// Base class for all menus to derive from.
    /// </summary>
    public abstract class Menu {
        #region Properties
        /// <summary>
        /// If the menu is currently
        /// </summary>
        public bool IsLoaded { get; private set; }

        /// <summary>
        /// If the menu is currently active and visible on screen.
        /// </summary>
        public bool IsActive {
            get { return instance?.activeSelf ?? false; }
            set { if (IsActive) { instance.SetActive(value); } }
        }

        /// <summary>
        /// The path where the prefab for this menu 
        /// exists in the project directory.
        /// </summary>
        protected abstract string PrefabPath { get; }
        #endregion

        #region Members
        /// <summary>
        /// The spawned instance of the menu.
        /// </summary>
        private GameObject instance;
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

            instance = Resources.Load<GameObject>(PrefabPath);
            instance.transform.SetParent(menuContainer);

            //Reset the rect transform
            RectTransform menuTransform = instance.GetComponent<RectTransform>();
            menuTransform.localScale = new Vector3(1, 1, 1);
            menuTransform.offsetMin  = new Vector2(0, 0);
            menuTransform.offsetMax  = new Vector2(0, 0);

            OnLoad();
        }

        /// <summary>
        /// Release the resources of the menu and destroy the gameobject.
        /// </summary>
        public void Destroy() {
            if (!IsLoaded) {
                throw new InvalidOperationException("Menu is not loaded! Cannot destroy.");
            }

            OnDestroy();
            GameObject.Destroy(instance);
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called right after the menu has been loaded.
        /// Use this to initialize resources.
        /// </summary>
        protected void OnLoad() {
        }

        /// <summary>
        /// Called right before the menu is destroyed.
        /// Use this to free up resources.
        /// </summary>
        protected void OnDestroy() {
        }

        protected void OnInput(string controlName, )
        #endregion
    }
}

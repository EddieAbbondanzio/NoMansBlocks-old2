using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.UI {
    /// <summary>
    /// Base class for game menus to derive from.
    /// </summary>
    public abstract class Menu {
        #region Properties
        /// <summary>
        /// If the menu is currently visible on
        /// screen for the player to see.
        /// </summary>
        public bool IsVisible {
            get { return Instance?.activeSelf ?? false; }
        }

        /// <summary>
        /// The path of where the prefab for instantiating
        /// can be found.
        /// </summary>
        protected abstract string PrefabPath { get; }

        /// <summary>
        /// The instance of the loaded prefab
        /// </summary>
        protected GameObject Instance { get; set; }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called after the new menu has been created.
        /// Use this to subscribe to events.
        /// </summary>
        protected virtual void OnLoad() {
        }

        /// <summary>
        /// Called right before the object is destroyed.
        /// Use this for any final calls, or resource
        /// releases.
        /// </summary>
        protected virtual void OnDestroy() {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load the menu into memory so it can be 
        /// used later on.
        /// </summary>
        /// <param name="menuContainer">The container to place
        /// the menu in.</param>
        public void Load(Transform menuContainer) {
            if (Instance == null) {
                //Pull in a new instance of the menu
                Instance = Resources.Load<GameObject>(PrefabPath);
                Instance.transform.SetParent(menuContainer);

                //Reset the rect transform
                RectTransform menuTransform = Instance.GetComponent<RectTransform>();
                menuTransform.localScale = new Vector3(1, 1, 1);
                menuTransform.offsetMin = new Vector2(0, 0);
                menuTransform.offsetMax = new Vector2(0, 0);

                OnLoad();
            }
            else {
                throw new Exception("Menu has already been instantiated!");
            }
        }

        /// <summary>
        /// Destroy the gameobject representing the
        /// menu to free up memory.
        /// </summary>
        public void Destroy() {
            if (Instance != null) {
                OnDestroy();
                GameObject.Destroy(Instance);
            }
        }

        /// <summary>
        /// Set the menu visible on screen for the 
        /// player to see.
        /// </summary>
        public void SetVisible() {
            if (Instance != null) {
                Instance.SetActive(true);
            }
        }

        /// <summary>
        /// Set the menu hidden as if it was never there.
        /// This keeps it loaded in memory though.
        /// </summary>
        public void SetHidden() {
            if (Instance != null) {
                Instance.SetActive(false);
            }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Search for a control using it's name as the
        /// search parameter.
        /// </summary>
        /// <typeparam name="T">The type of control to search for.</typeparam>
        /// <param name="name">The name of the control to find.</param>
        /// <returns>The control found. (If any).</returns>
        protected T FindControl<T>(string name) where T : class, IControlPresenter {
            Transform child = Instance.transform.Find(name);

            if(child != null) {
                return child.GetComponent<T>();
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Find all controls of type in the menu.
        /// </summary>
        /// <typeparam name="T">The type of control to look for.</typeparam>
        /// <returns>The collection of all controls matching the type
        /// passed in.</returns>
        protected T[] FindAllControlsOfType<T>() where T : class, IControlPresenter {
            return Instance.GetComponentsInChildren<T>();
        }
        #endregion
    }
}

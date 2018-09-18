using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Presenter to handle rendering a list of text to the
    /// screen. This provides the ability to scroll the list
    /// as well.
    /// </summary>
    [RequireComponent(typeof(ScrollRect))]
    public sealed class TextList : MonoBehaviour, IListControl<string> {
        #region Unity Fields
        /// <summary>
        /// The prefab to use to create new items with.
        /// </summary>
        public GameObject ItemPrefab;

        /// <summary>
        /// The content panel of the scroll rect.
        /// </summary>
        public GameObject ContentPanel;
        #endregion

        #region Properties
        /// <summary>
        /// The unique name of the list
        /// </summary>
        public string Name => gameObject.name;

        /// <summary>
        /// If the control is visible on screen and
        /// accepting input
        /// </summary>
        public bool Enabled {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        /// <summary>
        /// The list of items displayed in the control.
        /// </summary>
        public IList<string> DataSource { get; set; }
        #endregion

        #region Publics
        /// <summary>
        /// Databind the control so that it renders the latest
        /// version of the list on screen.
        /// </summary>
        public void DataBind() {
            //Improve this later
            foreach(Transform child in ContentPanel.transform) {
                GameObject.Destroy(child);
            }

            for(int i = 0, itemCount = DataSource.Count; i < itemCount; i++) {
                GameObject newItem = Instantiate(ItemPrefab) as GameObject;
                newItem.GetComponent<Text>().text = DataSource[i];

                newItem.transform.parent = ContentPanel.transform;
                newItem.transform.position = new Vector3(0, 0, 0);
                newItem.transform.localScale = Vector3.one;
            }
        }

        /// <summary>
        /// Clear out the control so it appears empty.
        /// </summary>
        public void Clear() {
            foreach (Transform child in ContentPanel.transform) {
                GameObject.Destroy(child);
            }
        }
        #endregion
    }
}

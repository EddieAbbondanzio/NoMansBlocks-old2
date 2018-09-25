using NoMansBlocks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// List control for rendering a list on the screen.
    /// </summary>
    [RequireComponent(typeof(LabelPool))]
    [RequireComponent(typeof(ScrollRect))]
    public sealed class TextList : MonoBehaviour, ITextList {
        #region Unity Fields
        [SerializeField]
        [Tooltip("The maximum number of items allowed in the list.")]
        private int capacity;
        #endregion

        #region Properties
        /// <summary>
        /// The unique name of the texbox
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
        /// The maximum number of values allowed in the list
        /// at any time.
        /// </summary>
        public int Capacity {
            get { return capacity; }
            set { capacity = value; }
        }

        /// <summary>
        /// The items currently in the list.
        /// </summary>
        public string[] Items {
            get { return items.ToArray(); }
            set { items = new TQueue<string>(value, Capacity); }
        }
        #endregion

        #region Members
        /// <summary>
        /// The underlying queue for holding the items.
        /// </summary>
        private TQueue<string> items;

        /// <summary>
        /// The pool of label ui objects to maintain.
        /// </summary>
        private IObjectPool<ILabel> labelPool;

        /// <summary>
        /// The active collection of UI Texts on screen.
        /// </summary>
        private List<ILabel> activeLabels;

        /// <summary>
        /// The unity scroll rect for handling scrolling.
        /// </summary>
        private ScrollRect scrollRect;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Ensure everything is valid when ever a value is changed in
        /// the editor.
        /// </summary>
        private void OnValidate() {
            if(Capacity < 1) {
                Debug.Log("Capacity must be greater than 0.");
                Capacity = 1;
            }
        }

        /// <summary>
        /// When the program first starts go out and find the pool, and
        /// set up the queue. Make sure the pools Capacity matches up with
        /// the list or else throw an error.
        /// </summary>
        private void Awake() {
            labelPool    = GetComponent<IObjectPool<ILabel>>();
            scrollRect   = GetComponent<ScrollRect>();
            items        = new TQueue<string>(Capacity);
            activeLabels = new List<ILabel>();

            //Do the capacitys match?
            if (labelPool.Capacity != Capacity) {
                throw new Exception(string.Format("{0} pool capacity does not match capacity", gameObject.name));
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Add a new item to the begining of the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(string item) {
            items.Enqueue(item);
            DataBind();
        }

        /// <summary>
        /// Clear all items from the list and make it blank.
        /// </summary>
        public void Clear() {
            items.Clear();
            DataBind();
        }

        /// <summary>
        /// Update the on screen representation to match
        /// up with the current state of it's text queue.
        /// </summary>
        public void DataBind() {
            //Find the difference
            int diff = activeLabels.Count - items.Count;

            //Sync up labels to items count
            while(diff != 0) {
                if(diff < 0) {
                    activeLabels.Add(labelPool.GetInstance());
                    diff++;
                }
                else if(diff > 0) {
                    int lastIndex = activeLabels.Count - 1;
                    ILabel label = activeLabels[lastIndex];
                    activeLabels.RemoveAt(lastIndex);

                    labelPool.ReturnInstance(label);
                    diff--;
                }
            }

            string[] itemArray = items.ToArray();
            //Set their values
            for (int i = 0; i < itemArray.Length; i++) {
                activeLabels[i].Text = itemArray[i];
            }

            ScrollToBottom();
        }

        /// <summary>
        /// Scroll to the very top of the scroll view.
        /// </summary>
        public void ScrollToTop() {
            Canvas.ForceUpdateCanvases();
            scrollRect.normalizedPosition = new Vector2(0, 1);
        }

        /// <summary>
        /// Scroll to the very bottom of the scroll view.
        /// </summary>
        public void ScrollToBottom() {
            Canvas.ForceUpdateCanvases();
            scrollRect.normalizedPosition = new Vector2(0, 0);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// A text label on the screen.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public sealed class Label : MonoBehaviour, ILabel {
        #region Properties
        /// <summary>
        /// The unique name of the button.
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
        /// The text being displayed in it.
        /// </summary>
        public string Text {
            get { return text.text; }
            set { text.text = value; }
        }
        #endregion

        #region Members
        /// <summary>
        /// The Unity Text Component.
        /// </summary>
        private Text text;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// When the script is first started, go out and 
        /// find the text component.
        /// </summary>
        private void Awake() {
            text = GetComponent<Text>();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Clear out the contents of the label.
        /// </summary>
        public void Clear() {
            text.text = string.Empty;
        }
        #endregion
    }
}

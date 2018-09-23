using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Control where users can provide input into a text
    /// box on the screen
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public sealed class TextBox : MonoBehaviour, ITextBox {
        #region Unity Fields
        [SerializeField]
        [Tooltip("If the contents of the textbox should be cleared when the user leaves it.")]
        private bool clearOnExit;
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
        /// The text inside of the textbox.
        /// </summary>
        public string Text {
            get { return inputField.text; }
            set { inputField.text = value; }
        }

        /// <summary>
        /// If the textbox should be cleared when the
        /// user leaves it.
        /// </summary>
        public bool ClearOnExit {
            get { return clearOnExit; }
            set { clearOnExit = value; }
        }
        #endregion

        #region Members
        /// <summary>
        /// The underlying InputField.
        /// </summary>
        private InputField inputField;
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired everytime the value of the textbox is changed.
        /// </summary>
        public event EventHandler<TextBoxEventArgs> OnEdit;

        /// <summary>
        /// Fired when the user has finished performing an edit.
        /// </summary>
        public event EventHandler<TextBoxEventArgs> OnEndEdit;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Locate the input field for this behaviour.
        /// </summary>
        private void Awake() {
            inputField = GetComponent<InputField>();
            inputField.onValueChanged.AddListener(OnEditListener);
            inputField.onEndEdit.AddListener(OnEndEditListener);
        }

        /// <summary>
        /// Release any listeners
        /// </summary>
        private void OnDestroy() {
            inputField.onValueChanged.RemoveListener(OnEditListener);
            inputField.onEndEdit.RemoveListener(OnEndEditListener);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Propogate the event for any listeners.
        /// </summary>
        /// <param name="value">The current value of the textbox</param>
        private void OnEditListener(string value) {
            if(OnEdit != null) {
                OnEdit(this, new TextBoxEventArgs(value));
            }
        }

        /// <summary>
        /// Propogate the event for any listeners.
        /// </summary>
        /// <param name="value">The current value of the textbox.</param>
        private void OnEndEditListener(string value) {
            if (OnEndEdit != null) {
                OnEndEdit(this, new TextBoxEventArgs(value));
            }

            if (ClearOnExit) {
                inputField.text = string.Empty;
            }
        }
        #endregion
    }
}

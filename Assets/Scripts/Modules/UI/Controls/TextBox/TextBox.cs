using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Control where users can provide input into a text
    /// box on the screen
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public sealed class TextBox : MonoBehaviour, ITextBox, ISelectHandler {

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
        /// If teh textbox is currently focused.
        /// </summary>
        public bool IsFocused { get { return inputField.isFocused; } }
        #endregion

        #region Members
        /// <summary>
        /// The underlying InputField.
        /// </summary>
        private InputField inputField;
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired when the textbox gains focus.
        /// </summary>
        public event EventHandler OnFocus;

        /// <summary>
        /// Fired when the textbox loses focus.
        /// </summary>
        public event EventHandler OnBlur;

        /// <summary>
        /// Fired everytime the value of the textbox is changed.
        /// </summary>
        public event EventHandler<TextBoxEventArgs> OnEdit;

        /// <summary>
        /// Fired when the user hits the submit button.
        /// </summary>
        public event EventHandler<TextBoxEventArgs> OnSubmit;
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

        #region Publics
        /// <summary>
        /// Clear out the contents of the textbox.
        /// </summary>
        public void Clear() {
            Text = string.Empty;
        }

        /// <summary>
        /// Focus on the textbox.
        /// </summary>
        public void Focus() {
            inputField.ActivateInputField();
        }

        /// <summary>
        /// Blur the textbox.
        /// </summary>
        public void Blur() {
            inputField.DeactivateInputField();
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
            TextBoxEventArgs args;

            if(UnityEngine.Input.GetKey(KeyCode.Return)) {
                if(OnSubmit != null) {
                    OnSubmit(this, new TextBoxEventArgs(value));
                }
            }
            
            if (OnBlur != null) {
                OnBlur(this, null);
            }
        }

        /// <summary>
        /// Propogates the on focus event for any listeners.
        /// </summary>
        /// <param name="eventData"></param>
        void ISelectHandler.OnSelect(BaseEventData eventData) {
            if(OnFocus != null) {
                OnFocus(this, null);
            }
        }
        #endregion
    }
}

﻿using System;
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
    public sealed class TextBoxBehaviour : MonoBehaviour, IControlBehaviour {
        #region Properties
        /// <summary>
        /// The unique name of the texbox
        /// </summary>
        public string Name => gameObject.name;

        /// <summary>
        /// Flag to indicate this is a text box control
        /// </summary>
        public ControlType ControlType => ControlType.TextBox;

        /// <summary>
        /// The text inside of the textbox.
        /// </summary>
        public string Text => InputField.text;

        /// <summary>
        /// The underlying InputField.
        /// </summary>
        private InputField InputField { get; set; }
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
            InputField = GetComponent<InputField>();
            InputField.onValueChanged.AddListener(OnEditListener);
            InputField.onEndEdit.AddListener(OnEndEditListener);
        }

        /// <summary>
        /// Release any listeners
        /// </summary>
        private void OnDestroy() {
            InputField.onValueChanged.RemoveListener(OnEditListener);
            InputField.onEndEdit.RemoveListener(OnEndEditListener);
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
            if(OnEndEdit != null) {
                OnEndEdit(this, new TextBoxEventArgs(value));
            }
        }
        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Standard button that fires off an event when the user
    /// clicks it.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public sealed class TriggerButtonBehaviour : MonoBehaviour, IControlBehaviour {
        #region Properties
        /// <summary>
        /// The unique name of the button.
        /// </summary>
        public string Name => gameObject.name;

        /// <summary>
        /// Flag to indicate this is a button control
        /// </summary>
        public ControlType ControlType => ControlType.Button;

        /// <summary>
        /// The cached reference to the button component.
        /// </summary>
        private Button Button { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired whenever the user clicks on the button.
        /// </summary>
        public event EventHandler OnClick;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Pull in the buttom component.
        /// </summary>
        private void Awake() {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(OnClickListener);
        }

        /// <summary>
        /// Remove the listener to prevent any memory
        /// leaks from occuring.
        /// </summary>
        private void OnDestroy() {
            Button.onClick.RemoveListener(OnClickListener);
        }
        #endregion

        #region Publics
        /// <summary>
        /// Set the label of the button. This is 
        /// the text displayed in the button.
        /// </summary>
        /// <param name="label">The label to put in it.</param>
        public void SetLabel(string label) {
            Text text = Button.GetComponentInChildren<Text>();
            text.text = label;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Fire off the public event for anyone listening.
        /// </summary>
        private void OnClickListener() {
            if (OnClick != null) {
                OnClick(this, null);
            }
        }
        #endregion
    }
}
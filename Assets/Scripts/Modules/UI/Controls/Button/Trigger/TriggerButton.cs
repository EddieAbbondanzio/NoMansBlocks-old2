using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Standard button that fires off an event when the user
    /// clicks it.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public sealed class TriggerButton : MonoBehaviour, ITriggerButton, ISelectHandler, IDeselectHandler {
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
        /// If the control is currently focused.
        /// </summary>
        public bool IsFocused { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The cached reference to the button component.
        /// </summary>
        private Button button;
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired whenever the user clicks on the button.
        /// </summary>
        public event EventHandler OnClick;
        
        /// <summary>
        /// Fired when the control is recieving focus.
        /// </summary>
        public event EventHandler OnFocus;

        /// <summary>
        /// Fired when the control is losing focus.
        /// </summary>
        public event EventHandler OnBlur;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Pull in the buttom component.
        /// </summary>
        private void Awake() {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClickListener);
        }

        /// <summary>
        /// Remove the listener to prevent any memory
        /// leaks from occuring.
        /// </summary>
        private void OnDestroy() {
            button.onClick.RemoveListener(OnClickListener);
        }

        /// <summary>
        /// Button is gaining focus. Update the isFocused property
        /// and fire off the event.
        /// </summary>
        void ISelectHandler.OnSelect(BaseEventData eventData) {
            IsFocused = true;

            if (OnFocus != null) {
                OnFocus(this, null);
            }
        }

        /// <summary>
        /// Button is losing focus. Set the is focused property and
        /// fire off the on blur event.
        /// </summary>
        void IDeselectHandler.OnDeselect(BaseEventData eventData) {
            IsFocused = false;

            if (OnBlur != null) {
                OnBlur(this, null);
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Set the label of the button. This is 
        /// the text displayed in the button.
        /// </summary>
        /// <param name="label">The label to put in it.</param>
        public void SetLabel(string label) {
            Text text = button.GetComponentInChildren<Text>();
            text.text = label;
        }

        /// <summary>
        /// Focus on the button.
        /// </summary>
        public void Focus() {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        /// <summary>
        /// Release focus from the button.
        /// </summary>
        public void Blur() {
            EventSystem.current.SetSelectedGameObject(null);
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
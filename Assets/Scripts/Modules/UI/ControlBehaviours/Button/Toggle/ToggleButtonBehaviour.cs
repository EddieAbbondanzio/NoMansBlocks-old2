using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Toggle button where the state of it flips between
    /// on and off with each click by the user.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public sealed class ToggleButtonBehaviour : MonoBehaviour, IControlBehaviour {
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
        /// The current state of the button.
        /// </summary>
        public ToggleButtonState State { get; set; }

        /// <summary>
        /// The cached reference to the button component.
        /// </summary>
        private Button Button { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired when the state of the button flip flops from
        /// Enabled to Disabled, or vice versa.
        /// </summary>
        public event EventHandler<ToggleButtonEventArgs> OnToggle;
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
            if(State == ToggleButtonState.Enabled) {
                State = ToggleButtonState.Disabled;
            }
            else {
                State = ToggleButtonState.Enabled;
            }

            if(OnToggle != null) {
                OnToggle(this, new ToggleButtonEventArgs(State));
            }
        }
        #endregion
    }
}
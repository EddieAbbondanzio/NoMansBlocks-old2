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
    /// Checkbox that allows a user to either agree or
    /// disagree with something.
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    public sealed class CheckBox : MonoBehaviour, ICheckBox {
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
        /// The group associated with this checkbox.
        /// It allows for limiting a group of toggles 
        /// to only have one enabled at a time.
        /// </summary>
        public ToggleGroup Group {
            get { return Toggle.group; }
            set { Toggle.group = value; }
        }

        /// <summary>
        /// If the checkbox is currently checked or not.
        /// </summary>
        public bool IsChecked {
            get { return Toggle.isOn; }
            set { Toggle.isOn = value; }
        }

        /// <summary>
        /// The underlying Unity Toggle.
        /// </summary>
        private Toggle Toggle { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired everytime the checked state of the checkbox
        /// is changed.
        /// </summary>
        public event EventHandler OnCheckChange;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Pull in the toggle component.
        /// </summary>
        private void Awake() {
            Toggle = GetComponent<Toggle>();
            Toggle.onValueChanged.AddListener(OnChangeListener);
        }

        /// <summary>
        /// Remove the listener to prevent any memory
        /// leaks from occuring.
        /// </summary>
        private void OnDestroy() {
            Toggle.onValueChanged.RemoveListener(OnChangeListener);
        }
        #endregion

        #region Publics
        /// <summary>
        /// Set the label of the check box. This is the
        /// text directly next to the box.
        /// </summary>
        /// <param name="label">The text to set it as.</param>
        public void SetLabel(string label) {
            Text text = Toggle.GetComponentInChildren<Text>();
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
        /// Helper to fire off the public event if anyone is listening.
        /// </summary>
        /// <param name="value">The current value of the check box.</param>
        private void OnChangeListener(bool value) {
            if(OnCheckChange != null) {
                OnCheckChange(this, null);
            }
        }
        #endregion
    }
}

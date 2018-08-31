using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Checkbox that allows a user to either agree or
    /// disagree with something.
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    public sealed class CheckBoxBehaviour : MonoBehaviour, IControlBehaviour {
        #region Properties
        /// <summary>
        /// The unique name of the button.
        /// </summary>
        public string Name => gameObject.name;

        /// <summary>
        /// Flag to indicate this is a checkbox control
        /// </summary>
        public ControlType ControlType => ControlType.CheckBox;

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
        /// The underlying Unity Toggle.
        /// </summary>
        private Toggle Toggle { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired everytime the checked state of the checkbox
        /// is changed.
        /// </summary>
        public event EventHandler<CheckBoxEventArgs> OnToggle;
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
        #endregion

        #region Helpers
        /// <summary>
        /// Helper to fire off the public event if anyone is listening.
        /// </summary>
        /// <param name="value">The current value of the check box.</param>
        private void OnChangeListener(bool value) {
            if(OnToggle != null) {
                OnToggle(this, new CheckBoxEventArgs(value));
            }
        }
        #endregion
    }
}

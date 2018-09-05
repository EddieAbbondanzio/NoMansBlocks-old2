using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.UI.Input {
    /// <summary>
    /// Coordinator that collects all of the controls in a menu
    /// view and handles creating a single source of input to 
    /// subscribe to.
    /// </summary>
    public sealed class InputControlCoordinator : MonoBehaviour, IInputControlCoordinator {
        #region Members
        /// <summary>
        /// The controls found on the prefab of this menu.
        /// </summary>
        private IControlHandler[] controls;
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired off everytime the user interacts with the menu is some manner.
        /// </summary>
        public event EventHandler<InputEventArgs> OnInput;
        #endregion

        #region Publics
        /// <summary>
        /// Search for a specific control in the view.
        /// </summary>
        /// <typeparam name="T">The control type to look for.</typeparam>
        /// <param name="name">The name of the control</param>
        /// <returns>The control if found</returns>
        public T GetControl<T>(string name) where T : class, IControlHandler {
            for(int i = 0; i < controls.Length; i++) {
                if(typeof(T).IsAssignableFrom(controls[i].GetType()) && controls[i].Name == name) {
                    return controls[i] as T;
                }
            }

            return null;
        }

        /// <summary>
        /// Search for all controls of a specific type.
        /// </summary>
        /// <typeparam name="T">The type to hunt for.</typeparam>
        /// <returns>The controls of the matching type</returns>
        public List<T> GetControls<T>() where T : class, IControlHandler {
            List<T> matchingControls = new List<T>();

            for(int i = 0; i < controls.Length; i++) {
                if(typeof(T).IsAssignableFrom(controls[i].GetType())) {
                    matchingControls.Add(controls[i] as T);
                }
            }

            return matchingControls;
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called when the object is first initialized. 
        /// </summary>
        private void Awake() {
            controls = GetComponentsInChildren<IControlHandler>();

            //Subscribe to every control
            for (int i = 0; i < controls.Length; i++) {
                switch (controls[i].ControlType) {
                    case ControlType.ToggleButton:
                        IToggleButtonHandler toggleButton = controls[i] as IToggleButtonHandler;
                        toggleButton.OnToggle += OnToggleButtonToggle;
                        break;

                    case ControlType.TriggerButton:
                        ITriggerButtonHandler triggerButton = controls[i] as ITriggerButtonHandler;
                        triggerButton.OnClick += OnTriggerButtonClick;
                        break;

                    case ControlType.CheckBox:
                        ICheckBoxHandler checkBox = controls[i] as ICheckBoxHandler;
                        checkBox.OnCheckChange += OnCheckBoxChange;
                        break;

                    case ControlType.TextBox:
                        ITextBoxHandler textBox = controls[i] as ITextBoxHandler;
                        textBox.OnEdit += OnTextBoxEdit;
                        textBox.OnEndEdit += OnTextBoxEndEdit;
                        break;
                }
            }
        }

        /// <summary>
        /// Called when the prefab is destroyed. This releases resources
        /// to prevent memory leaks.
        /// </summary>
        private void OnDestroy() {
            for (int i = 0; i < controls.Length; i++) {
                switch (controls[i].ControlType) {
                    case ControlType.ToggleButton:
                        IToggleButtonHandler toggleButton = controls[i] as IToggleButtonHandler;
                        toggleButton.OnToggle -= OnToggleButtonToggle;
                        break;

                    case ControlType.TriggerButton:
                        ITriggerButtonHandler triggerButton = controls[i] as ITriggerButtonHandler;
                        triggerButton.OnClick -= OnTriggerButtonClick;
                        break;

                    case ControlType.CheckBox:
                        ICheckBoxHandler checkBox = controls[i] as ICheckBoxHandler;
                        checkBox.OnCheckChange -= OnCheckBoxChange;
                        break;

                    case ControlType.TextBox:
                        ITextBoxHandler textBox = controls[i] as ITextBoxHandler;
                        textBox.OnEdit    -= OnTextBoxEdit;
                        textBox.OnEndEdit -= OnTextBoxEndEdit;
                        break;
                }
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Processess inputs from toggle buttons and propogates
        /// their event publicly.
        /// </summary>
        /// <param name="sender">The button that was toggled.</param>
        /// <param name="e">Always null</param>
        private void OnToggleButtonToggle(object sender, EventArgs e) {
            IToggleButtonHandler toggleButton = sender as IToggleButtonHandler;

            if (OnInput != null) {
                OnInput(this, new InputEventArgs(toggleButton, InputActionType.Click));
            }
        }

        /// <summary>
        /// Processess inputs from trigger buttons and propogates
        /// their input event publicly.
        /// </summary>
        /// <param name="sender">The button that was triggered</param>
        /// <param name="e">Always null</param>
        private void OnTriggerButtonClick(object sender, EventArgs e) {
            ITriggerButtonHandler triggerButton = sender as ITriggerButtonHandler;

            if (OnInput != null) {
                OnInput(this, new InputEventArgs(triggerButton, InputActionType.Click));
            }
        }

        /// <summary>
        /// Processess inputs from checkbox controls and propogates
        /// their input event publicly.
        /// </summary>
        /// <param name="sender">The checkbox that was checked.</param>
        /// <param name="e">Always null</param>
        private void OnCheckBoxChange(object sender, EventArgs e) {
            ICheckBoxHandler checkBox = sender as ICheckBoxHandler;

            if (OnInput != null) {
                OnInput(this, new InputEventArgs(checkBox, InputActionType.Click));
            }
        }

        /// <summary>
        /// Processess inputs from textboxes that had their value changed,
        /// but the final edit hasnt been made yet.
        /// </summary>
        /// <param name="sender">The textbox being modified.</param>
        /// <param name="e">Always null.</param>
        private void OnTextBoxEdit(object sender, EventArgs e) {
            ITextBoxHandler textBox = sender as ITextBoxHandler;

            if (OnInput != null) {
                OnInput(this, new InputEventArgs(textBox, InputActionType.Edit));
            }
        }

        /// <summary>
        /// Processess inputs from textboxes that have been finished
        /// being modified and propogates it publicly.
        /// </summary>
        /// <param name="sender">The textbox that was done being editted.</param>
        /// <param name="e"></param>
        private void OnTextBoxEndEdit(object sender, EventArgs e) {
            ITextBoxHandler textBox = sender as ITextBoxHandler;

            if (OnInput != null) {
                OnInput(this, new InputEventArgs(textBox, InputActionType.EndEdit));
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.UI.Presenter {
    /// <summary>
    /// Mediator for control views. This finds all the views and
    /// subscribes to their inputs. Then the menu model can listen
    /// to this single source for input.
    /// </summary>
    public sealed class MenuPresenter : MonoBehaviour {
        #region Members
        /// <summary>
        /// The controls found on the prefab of this menu.
        /// </summary>
        private IControlPresenter[] controls;
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired off everytime the user interacts with the menu is some manner.
        /// </summary>
        public event EventHandler<InputEventArgs> OnInput;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called when the object is first initialized. 
        /// </summary>
        private void Awake() {
            controls = GetComponentsInChildren<IControlPresenter>();

            //Subscribe to every control
            for(int i = 0; i < controls.Length; i++) {
                switch (controls[i].ControlType) {
                    case ControlType.ToggleButton:
                        IToggleButtonPresenter toggleButton = controls[i] as IToggleButtonPresenter;
                        toggleButton.OnToggle += OnToggleButtonToggle;
                        break;

                    case ControlType.TriggerButton:
                        ITriggerButtonPresenter triggerButton = controls[i] as ITriggerButtonPresenter;
                        triggerButton.OnClick += OnTriggerButtonClick;
                        break;

                    case ControlType.CheckBox:
                        ICheckBoxPresenter checkBox = controls[i] as ICheckBoxPresenter;
                        checkBox.OnCheckChange += OnCheckBoxChange;
                        break;

                    case ControlType.TextBox:
                        ITextBoxPresenter textBox = controls[i] as ITextBoxPresenter;
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
                        IToggleButtonPresenter toggleButton = controls[i] as IToggleButtonPresenter;
                        toggleButton.OnToggle -= OnToggleButtonToggle;
                        break;

                    case ControlType.TriggerButton:
                        ITriggerButtonPresenter triggerButton = controls[i] as ITriggerButtonPresenter;
                        triggerButton.OnClick -= OnTriggerButtonClick;
                        break;

                    case ControlType.CheckBox:
                        ICheckBoxPresenter checkBox = controls[i] as ICheckBoxPresenter;
                        checkBox.OnCheckChange -= OnCheckBoxChange;
                        break;

                    case ControlType.TextBox:
                        ITextBoxPresenter textBox = controls[i] as ITextBoxPresenter;
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
            IToggleButtonPresenter toggleButton = sender as IToggleButtonPresenter;

            if(OnInput != null) {
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
            ITriggerButtonPresenter triggerButton = sender as ITriggerButtonPresenter;

            if(OnInput != null) {
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
            ICheckBoxPresenter checkBox = sender as ICheckBoxPresenter;

            if(OnInput != null) {
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
            ITextBoxPresenter textBox = sender as ITextBoxPresenter;

            if(OnInput != null) {
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
            ITextBoxPresenter textBox = sender as ITextBoxPresenter;

            if(OnInput != null) {
                OnInput(this, new InputEventArgs(textBox, InputActionType.EndEdit));
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// The standard computer mouse. This is an event driven
    /// wrapper around Unity's Input class to prevent the need from
    /// manually polling the input state.
    /// </summary>
    public class Mouse : InputDevice {
        #region Statics
        /// <summary>
        /// The singleton instance.
        /// </summary>
        private static Mouse instance;
        #endregion

        #region Members
        /// <summary>
        /// The list of active handlers for any of the buttons on the mouse.
        /// Each one is responsible for managing a single button.
        /// </summary>
        private List<MouseButtonHandler> buttonHandlers;

        /// <summary>
        /// The list of active handlers for any of the axes on the mouse.
        /// Each one is responsible for a single axis.
        /// </summary>
        private List<MouseAxisHandler> axisHandlers;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the mouse device. Only one
        /// is permitted at any time.
        /// </summary>
        /// <param name="deviceManager">The manager that owns this device.</param>
        /// <param name="inputPoller">The poller to check input state from.</param>
        public Mouse(IInputDeviceManager deviceManager, IInputPoller inputPoller) : base(deviceManager, inputPoller) {
            if(instance == null) {
                instance = this;
            }
            else {
                throw new Exception("There is already a mouse instance present. Did you call InputModule.GetDevice<Mouse>()?");
            }
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Process the input from the input poller.
        /// </summary>
        /// <param name="inputPoller">Checks the current input state of the engine.</param>
        protected override void Update(IInputPoller inputPoller) {
            for(int i = 0, buttonHandlerCount = buttonHandlers.Count; i < buttonHandlerCount; i++) {
                buttonHandlers[i].Update(inputPoller);
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Add a new event listener to the specific mouse button,
        /// and action.
        /// </summary>
        /// <param name="button">The button to listen for.</param>
        /// <param name="action">It's life cycle event to listen for.</param>
        /// <param name="listener">The listener to invoke.</param>
        public void AddListener(MouseButton button, MouseButtonAction action, MouseButtonListener listener) {
            if (buttonHandlers != null) {
                for (int i = 0, keyHandlerCount = buttonHandlers.Count; i < keyHandlerCount; i++) {
                    if (buttonHandlers[i].Button == button) {
                        buttonHandlers[i].AddListener(action, listener);
                        return;
                    }
                }
            }
            else {
                buttonHandlers = new List<MouseButtonHandler>();
            }

            MouseButtonHandler buttonHandler = new MouseButtonHandler(button);
            buttonHandler.AddListener(action, listener);
            buttonHandlers.Add(buttonHandler);
        }

        /// <summary>
        /// Add a new axis event listener to the specific mouse
        /// axis.
        /// </summary>
        /// <param name="axis">The axis to listen to.</param>
        /// <param name="listener">The listener to notify.</param>
        public void AddListener(MouseAxis axis, MouseAxisListener listener) {
            if(axisHandlers != null) {
                for(int i = 0, axisHandlerCount = axisHandlers.Count; i < axisHandlerCount; i++) {
                    if(axisHandlers[i].Axis == axis) {
                        axisHandlers[i].AddListener(listener);
                        return;
                    }
                }
            }
            else {
                axisHandlers = new List<MouseAxisHandler>();
            }

            MouseAxisHandler axisHandler = new MouseAxisHandler(axis);
            axisHandler.AddListener(listener);
            axisHandlers.Add(axisHandler);
        }

        /// <summary>
        /// Remove an existing listener from it's key and action.
        /// </summary>
        /// <param name="button">The button to remove a listener from.</param>
        /// <param name="action">The action to stop listening to.</param>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveListener(MouseButton button, MouseButtonAction action, MouseButtonListener listener) {
            if (buttonHandlers != null) {
                for (int i = 0, keyHandlerCount = buttonHandlers.Count; i < keyHandlerCount; i++) {
                    if (buttonHandlers[i].Button == button) {
                        buttonHandlers[i].RemoveListener(action, listener);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Remove an existing listener from it's axis.
        /// </summary>
        /// <param name="axis">The axis to remove a listener from.</param>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveListener(MouseAxis axis, MouseAxisListener listener) {
            if(axisHandlers != null) {
                for(int i = 0, axisHandlerCount = axisHandlers.Count; i < axisHandlerCount; i++) {
                    if(axisHandlers[i].Axis == axis) {
                        axisHandlers[i].RemoveListener(listener);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Remove every single listener from the mouse.
        /// </summary>
        public void RemoveAllListeners() {
            buttonHandlers = null;
        }

        /// <summary>
        /// Remove every single listener from a single
        /// button of the mouse.
        /// </summary>
        /// <param name="button">The button to remove listeners from.</param>
        public void RemoveAllListeners(MouseButton button) {
            if (buttonHandlers != null) {
                for (int i = 0, keyCount = buttonHandlers.Count; i < keyCount; i++) {
                    if (buttonHandlers[i].Button == button) {
                        buttonHandlers.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Remove every single listener from a single
        /// axis of the mouse.
        /// </summary>
        /// <param name="axis"></param>
        public void RemoveAllListeners(MouseAxis axis) {
            if(axisHandlers != null) {
                for(int i = 0, axisHandlerCount = axisHandlers.Count; i < axisHandlerCount; i++) {
                    if(axisHandlers[i].Axis == axis) {
                        axisHandlers.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Remove very single listener from a button
        /// and action of it.
        /// </summary>
        /// <param name="button">The button to remove listeners from.</param>
        /// <param name="action">The action to clear listeners of.</param>
        public void RemoveAllListeners(MouseButton button, MouseButtonAction action) {
            for (int i = 0, keyCount = buttonHandlers.Count; i < keyCount; i++) {
                if (buttonHandlers[i].Button == button) {
                    buttonHandlers[i].RemoveAllListeners(action);
                    break;
                }
            }
        }
        #endregion
    }
}

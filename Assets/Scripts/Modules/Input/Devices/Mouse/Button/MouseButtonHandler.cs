using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Handler for a single mouse button.
    /// </summary>
    public sealed class MouseButtonHandler : IInputHandler {
        #region Properties
        /// <summary>
        /// The mouse button it handles.
        /// </summary>
        public MouseButton Button { get; }
        #endregion

        #region Members
        /// <summary>
        /// The collection of listeners to inform the first frame
        /// that the button is clicked on.
        /// </summary>
        private List<MouseButtonListener> downListeners;

        /// <summary>
        /// The collection of listeners to inform any frame
        /// that the button is currently down on.
        /// </summary>
        private List<MouseButtonListener> pressedListeners;

        /// <summary>
        /// The collection of listeners to inform on the frame that
        /// the mouse button is released on.
        /// </summary>
        private List<MouseButtonListener> upListeners;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new mouse button handler with no listeners.
        /// </summary>
        /// <param name="button">The button it listens to.</param>
        public MouseButtonHandler(MouseButton button) {
            Button = button;
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Update this handler and propogate the input for any 
        /// of it's listeners.
        /// </summary>
        /// <param name="inputPoller">The poller to get current input.</param>
        public void Update(IInputPoller inputPoller) {
            if (downListeners != null && inputPoller.IsMouseButtonDown((int)Button)){
                for (int i = 0, downCount = downListeners.Count; i < downCount; i++) {
                    downListeners[i](Button, MouseButtonAction.Down);
                }
            }
            if(pressedListeners != null && inputPoller.IsMouseButtonPressed((int)Button)) {
                for (int i = 0, pressedCount = pressedListeners.Count; i < pressedCount; i++) {
                    pressedListeners[i](Button, MouseButtonAction.Pressed);
                }
            }
            if(upListeners != null && inputPoller.IsMouseButtonUp((int)Button)) {
                for (int i = 0, upCount = upListeners.Count; i < upCount; i++) {
                    upListeners[i](Button, MouseButtonAction.Up);
                }
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Add a new listener to the specific action passed in.
        /// </summary>
        /// <param name="action">The action to listen for.</param>
        /// <param name="listener">The listener to alert.</param>
        public void AddListener(MouseButtonAction action, MouseButtonListener listener) {
            switch (action) {
                case MouseButtonAction.Down:
                    if (downListeners == null) {
                        downListeners = new List<MouseButtonListener>();
                    }

                    downListeners.Add(listener);
                    break;
                case MouseButtonAction.Pressed:
                    if (pressedListeners == null) {
                        pressedListeners = new List<MouseButtonListener>();
                    }

                    pressedListeners.Add(listener);
                    break;
                case MouseButtonAction.Up:
                    if (upListeners == null) {
                        upListeners = new List<MouseButtonListener>();
                    }

                    upListeners.Add(listener);
                    break;
            }
        }

        /// <summary>
        /// Remove a specific listener from the action.
        /// </summary>
        /// <param name="action">The action to remove a listener of.</param>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveListener(MouseButtonAction action, MouseButtonListener listener) {
            switch (action) {
                case MouseButtonAction.Down:
                    if (downListeners != null) {
                        for (int i = 0, downCount = downListeners.Count; i < downCount; i++) {
                            if (downListeners[i] == listener) {
                                downListeners.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
                case MouseButtonAction.Pressed:
                    if (pressedListeners != null) {
                        for (int i = 0, pressedCount = pressedListeners.Count; i < pressedCount; i++) {
                            if (pressedListeners[i] == listener) {
                                pressedListeners.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
                case MouseButtonAction.Up:
                    if (upListeners != null) {
                        for (int i = 0, upCount = upListeners.Count; i < upCount; i++) {
                            if (upListeners[i] == listener) {
                                upListeners.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Remove every single listener from the button handler.
        /// </summary>
        public void RemoveAllListeners() {
            downListeners    = null;
            pressedListeners = null;
            upListeners      = null;
        }

        /// <summary>
        /// Remove all listeners from a specific action of the mouse
        /// button handler.
        /// </summary>
        /// <param name="action">The action to remove all listeners from.</param>
        public void RemoveAllListeners(MouseButtonAction action) {
            switch (action) {
                case MouseButtonAction.Down:
                    downListeners = null;
                    break;

                case MouseButtonAction.Pressed:
                    pressedListeners = null;
                    break;

                case MouseButtonAction.Up:
                    upListeners = null;
                    break;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Handler for a single keyboard key.
    /// </summary>
    public sealed class KeyboardKeyHandler {
        #region Properties
        /// <summary>
        /// The key it handles.
        /// </summary>
        public KeyboardKey Key { get; }
        #endregion

        #region Members
        /// <summary>
        /// The list of listeners to invoke on the first frame that
        /// the keyboard key we are handling is pressed down.
        /// </summary>
        private List<KeyboardKeyListener> downListeners;

        /// <summary>
        /// The list of listeners to invoke each frame when the key 
        /// we are handling is pressed.
        /// </summary>
        private List<KeyboardKeyListener> pressedListeners;

        /// <summary>
        /// The list of listeners to call on the first frame that
        /// the keyboard key we are handling is released.
        /// </summary>
        private List<KeyboardKeyListener> upListeners;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new key handler with no listeners.
        /// </summary>
        /// <param name="key">The key it listens too.</param>
        public KeyboardKeyHandler(KeyboardKey key) {
            Key = key;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Update this handler and propogate the input for any 
        /// of it's listeners.
        /// </summary>
        /// <param name="inputPoller">The poller to get current input.</param>
        public void Update(IInputPoller inputPoller) {
            KeyCode code = Keyboard.ConvertKeyToKeyCode(Key);

            if (downListeners != null && inputPoller.IsButtonDown(code)){
                for (int i = 0, downCount = downListeners.Count; i < downCount; i++) {
                    downListeners[i](Key, KeyboardKeyAction.Down);
                }
            }
            if (pressedListeners != null && inputPoller.IsButtonPressed(code)) {
                for (int i = 0, pressedCount = pressedListeners.Count; i < pressedCount; i++) {
                    pressedListeners[i](Key, KeyboardKeyAction.Pressed);
                }
            }
            if (upListeners != null && inputPoller.IsButtonUp(code)) {
                for (int i = 0, upCount = upListeners.Count; i < upCount; i++) {
                    upListeners[i](Key, KeyboardKeyAction.Up);
                }
            }
        }

        /// <summary>
        /// Add a new listener to the specific action passed in.
        /// </summary>
        /// <param name="action">The action to listen for.</param>
        /// <param name="listener">The listener to alert.</param>
        public void AddListener(KeyboardKeyAction action, KeyboardKeyListener listener) {
            switch (action) {
                case KeyboardKeyAction.Down:
                    if(downListeners == null) {
                        downListeners = new List<KeyboardKeyListener>();
                    }

                    downListeners.Add(listener);
                    break;
                case KeyboardKeyAction.Pressed:
                    if(pressedListeners == null) {
                        pressedListeners = new List<KeyboardKeyListener>();
                    }

                    pressedListeners.Add(listener);
                    break;
                case KeyboardKeyAction.Up:
                    if(upListeners == null) {
                        upListeners = new List<KeyboardKeyListener>();
                    }

                    upListeners.Add(listener);
                    break;
            }
        }

        /// <summary>
        /// Remove an existing listener from an action.
        /// </summary>
        /// <param name="action">The action to remove a listener from.</param>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveListener(KeyboardKeyAction action, KeyboardKeyListener listener) {
            switch (action) {
                case KeyboardKeyAction.Down:
                    if (downListeners != null) {
                        for (int i = 0, downCount = downListeners.Count; i < downCount; i++) {
                            if(downListeners[i] == listener) {
                                downListeners.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
                case KeyboardKeyAction.Pressed:
                    if(pressedListeners != null) {
                        for(int i = 0, pressedCount = pressedListeners.Count; i < pressedCount; i++) {
                            if(pressedListeners[i] == listener) {
                                pressedListeners.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
                case KeyboardKeyAction.Up:
                    if(upListeners != null) {
                        for(int i = 0, upCount = upListeners.Count; i < upCount; i++) {
                            if(upListeners[i] == listener) {
                                upListeners.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Remove every single listener from the key handler.
        /// </summary>
        public void RemoveAllListeners() {
            downListeners    = null;
            pressedListeners = null;
            upListeners      = null;
        }
        
        /// <summary>
        /// Remove all listeners from a specific action of
        /// the key handler.
        /// </summary>
        /// <param name="action">The action to remove listeners from.</param>
        public void RemoveAllListeners(KeyboardKeyAction action) {
            switch (action) {
                case KeyboardKeyAction.Down:
                    downListeners = null;
                    break;

                case KeyboardKeyAction.Pressed:
                    pressedListeners = null;
                    break;

                case KeyboardKeyAction.Up:
                    upListeners = null;
                    break;
            }
        }
        #endregion
    }
}

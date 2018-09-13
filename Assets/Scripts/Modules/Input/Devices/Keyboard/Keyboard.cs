using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Standard keyboard of the computer. This is an event driven
    /// wrapper around Unity's Input class to prevent the need from
    /// manually polling the input state.
    /// </summary>
    public sealed class Keyboard : InputDevice {
        #region Statics
        /// <summary>
        /// The singleton instance.
        /// </summary>
        private static Keyboard instance;
        #endregion

        #region Members
        /// <summary>
        /// The list of active handlers that are managing
        /// the keys of the keyboard. There will not always be
        /// a handler for every key, since not all will have listeners.
        /// </summary>
        private List<KeyboardKeyHandler> keyHandlers;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the keyboard device. Only
        /// one is permitted at any time.
        /// </summary>
        /// <param name="deviceManager">The manager that owns this device.</param>
        /// <param name="inputPoller">The poller to check input state from.</param>
        public Keyboard(IInputDeviceManager deviceManager, IInputPoller inputPoller) : base(deviceManager, inputPoller) {
            if(instance == null) {
                instance = this;
            }
            else {
                throw new Exception("There is already a keyboard instance present. Did you call InputModule.GetDevice<Keyboard>()?");
            }
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Process the input from the input poller.
        /// </summary>
        ///<param name="inputPoller">The currnet input state checker.</param>
        protected override void Update(IInputPoller inputPoller) {
            for (int i = 0, keyHandlerCount = keyHandlers.Count; i < keyHandlerCount; i++) {
                keyHandlers[i].Update(inputPoller);
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Add a new event listener to the specific key, and action. 
        /// </summary>
        /// <param name="key">The key to listen for.</param>
        /// <param name="action">It's life cycle event to listen for.</param>
        /// <param name="listener">The method to call back.</param>
        public void AddListener(KeyboardKey key, KeyboardKeyAction action, KeyboardKeyListener listener) {
            if (keyHandlers != null) {
                for (int i = 0, keyHandlerCount = keyHandlers.Count; i < keyHandlerCount; i++) {
                    if (keyHandlers[i].Key == key) {
                        keyHandlers[i].AddListener(action, listener);
                        return;
                    }
                }
            }
            else {
                keyHandlers = new List<KeyboardKeyHandler>();
            }

            KeyboardKeyHandler keyHandler = new KeyboardKeyHandler(key);
            keyHandler.AddListener(action, listener);
            keyHandlers.Add(keyHandler);
        }

        /// <summary>
        /// Remove a specific listener from a key and a certain action
        /// of it.
        /// </summary>
        /// <param name="key">The key to remove a listener from.</param>
        /// <param name="action">The action to remove from.</param>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveListener(KeyboardKey key, KeyboardKeyAction action, KeyboardKeyListener listener) {
            if (keyHandlers != null) {
                for (int i = 0, keyHandlerCount = keyHandlers.Count; i < keyHandlerCount; i++) {
                    if (keyHandlers[i].Key == key) {
                        keyHandlers[i].RemoveListener(action, listener);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Remove every single listener from the keyboard.
        /// </summary>
        public void RemoveAllListeners() {
            keyHandlers = null;
        }

        /// <summary>
        /// Remove every single listener from a specific key.
        /// </summary>
        /// <param name="key">The key to remove listeners from.</param>
        public void RemoveAllListeners(KeyboardKey key) {
            if (keyHandlers != null) {
                for (int i = 0, keyCount = keyHandlers.Count; i < keyCount; i++) {
                    if (keyHandlers[i].Key == key) {
                        keyHandlers.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Remove every single listener from a speciifc key, and a specific
        /// action of it.
        /// </summary>
        /// <param name="key">The key to remove listeners from.</param>
        /// <param name="action">The action to clear listeners from.</param>
        public void RemoveAllListeners(KeyboardKey key, KeyboardKeyAction action) {
            for(int i = 0, keyCount = keyHandlers.Count; i < keyCount; i++) {
                if(keyHandlers[i].Key == key) {
                    keyHandlers[i].RemoveAllListeners(action);
                    break;
                }
            }
        }
        #endregion
    }
}

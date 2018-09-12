using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Standard keyboard of the computer.
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

        #region Helpers
        /// <summary>
        /// Process the input from the input poller.
        /// </summary>
        ///<param name="inputPoller">The currnet input state checker.</param>
        protected override void Update(IInputPoller inputPoller) {
            for(int i = 0, keyHandlerCount = keyHandlers.Count; i < keyHandlerCount; i++) {
                keyHandlers[i].Update(inputPoller);
            }
        }

        /// <summary>
        /// Takes an input of a keyboard key and converts it
        /// to Unitys KeyCode variant.
        /// </summary>
        /// <param name="key">The keyboard key to convert.</param>
        /// <returns>The Unity keycode.</returns>
        public static KeyCode ConvertKeyToKeyCode(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.A:
                    return KeyCode.A;
                case KeyboardKey.B:
                    return KeyCode.B;
                case KeyboardKey.C:
                    return KeyCode.C;
                case KeyboardKey.D:
                    return KeyCode.D;
                case KeyboardKey.E:
                    return KeyCode.E;
                case KeyboardKey.F:
                    return KeyCode.F;
                case KeyboardKey.G:
                    return KeyCode.G;
                case KeyboardKey.H:
                    return KeyCode.H;
                case KeyboardKey.I:
                    return KeyCode.I;
                case KeyboardKey.J:
                    return KeyCode.J;
                case KeyboardKey.K:
                    return KeyCode.K;
                case KeyboardKey.L:
                    return KeyCode.L;
                case KeyboardKey.M:
                    return KeyCode.M;
                case KeyboardKey.N:
                    return KeyCode.N;
                case KeyboardKey.O:
                    return KeyCode.O;
                case KeyboardKey.P:
                    return KeyCode.P;
                case KeyboardKey.Q:
                    return KeyCode.Q;
                case KeyboardKey.R:
                    return KeyCode.R;
                case KeyboardKey.S:
                    return KeyCode.S;
                case KeyboardKey.T:
                    return KeyCode.T;
                case KeyboardKey.U:
                    return KeyCode.U;
                case KeyboardKey.V:
                    return KeyCode.V;
                case KeyboardKey.W:
                    return KeyCode.W;
                case KeyboardKey.X:
                    return KeyCode.X;
                case KeyboardKey.Y:
                    return KeyCode.Y;
                case KeyboardKey.Z:
                    return KeyCode.Z;
                case KeyboardKey.Alpha0:
                    return KeyCode.Alpha0;
                case KeyboardKey.Alpha1:
                    return KeyCode.Alpha1;
                case KeyboardKey.Alpha2:
                    return KeyCode.Alpha2;
                case KeyboardKey.Alpha3:
                    return KeyCode.Alpha3;
                case KeyboardKey.Alpha4:
                    return KeyCode.Alpha4;
                case KeyboardKey.Alpha5:
                    return KeyCode.Alpha5;
                case KeyboardKey.Alpha6:
                    return KeyCode.Alpha6;
                case KeyboardKey.Alpha7:
                    return KeyCode.Alpha7;
                case KeyboardKey.Alpha8:
                    return KeyCode.Alpha8;
                case KeyboardKey.Alpha9:
                    return KeyCode.Alpha9;
                case KeyboardKey.BackQuote:
                    return KeyCode.BackQuote;
                case KeyboardKey.ForwardQuote:
                    return KeyCode.Quote;
                case KeyboardKey.DoubleQuote:
                    return KeyCode.DoubleQuote;
                case KeyboardKey.Semicolon:
                    return KeyCode.Semicolon;
                case KeyboardKey.LeftBracket:
                    return KeyCode.LeftBracket;
                case KeyboardKey.RightBracket:
                    return KeyCode.RightBracket;
                case KeyboardKey.ForwardSlash:
                    return KeyCode.Slash;
                case KeyboardKey.BackSlash:
                    return KeyCode.Backslash;
                case KeyboardKey.LeftShift:
                    return KeyCode.LeftShift;
                case KeyboardKey.RightShift:
                    return KeyCode.RightShift;
                case KeyboardKey.LeftControl:
                    return KeyCode.LeftControl;
                case KeyboardKey.RightControl:
                    return KeyCode.RightControl;
                case KeyboardKey.LeftAlt:
                    return KeyCode.LeftAlt;
                case KeyboardKey.RightAlt:
                    return KeyCode.RightAlt;
                case KeyboardKey.CapsLock:
                    return KeyCode.CapsLock;
                case KeyboardKey.Tab:
                    return KeyCode.Tab;
                case KeyboardKey.AlphaEnter:
                    return KeyCode.Return;
                case KeyboardKey.Backspace:
                    return KeyCode.Backspace;
                case KeyboardKey.Delete:
                    return KeyCode.Delete;
                case KeyboardKey.Escape:
                    return KeyCode.Escape;
                case KeyboardKey.Insert:
                    return KeyCode.Insert;
                case KeyboardKey.Home:
                    return KeyCode.Home;
                case KeyboardKey.PageUp:
                    return KeyCode.PageUp;
                case KeyboardKey.PageDown:
                    return KeyCode.PageDown;
                case KeyboardKey.End:
                    return KeyCode.End;
                case KeyboardKey.UpArrow:
                    return KeyCode.UpArrow;
                case KeyboardKey.DownArrow:
                    return KeyCode.DownArrow;
                case KeyboardKey.LeftArrow:
                    return KeyCode.LeftArrow;
                case KeyboardKey.RightArrow:
                    return KeyCode.RightArrow;
                case KeyboardKey.Minus:
                    return KeyCode.Minus;
                case KeyboardKey.Plus:
                    return KeyCode.Plus;
                case KeyboardKey.Keypad0:
                    return KeyCode.Keypad0;
                case KeyboardKey.Keypad1:
                    return KeyCode.Keypad1;
                case KeyboardKey.Keypad2:
                    return KeyCode.Keypad2;
                case KeyboardKey.Keypad3:
                    return KeyCode.Keypad3;
                case KeyboardKey.Keypad4:
                    return KeyCode.Keypad4;
                case KeyboardKey.Keypad5:
                    return KeyCode.Keypad5;
                case KeyboardKey.Keypad6:
                    return KeyCode.Keypad6;
                case KeyboardKey.Keypad7:
                    return KeyCode.Keypad7;
                case KeyboardKey.Keypad8:
                    return KeyCode.Keypad8;
                case KeyboardKey.Keypad9:
                    return KeyCode.Keypad9;
                case KeyboardKey.KeypadEnter:
                    return KeyCode.KeypadEnter;
                case KeyboardKey.KeypadPlus:
                    return KeyCode.KeypadPlus;
                case KeyboardKey.KeypadMinus:
                    return KeyCode.KeypadMinus;
                case KeyboardKey.KeypadMultiply:
                    return KeyCode.KeypadMultiply;
                case KeyboardKey.KeypadDivide:
                    return KeyCode.KeypadDivide;
                case KeyboardKey.KeypadPeriod:
                    return KeyCode.KeypadPeriod;
                default:
                    throw new NotSupportedException(string.Format("KeyboardKey: {0} is not supported.", key.ToString()));
            }
            #endregion
        }
    }
}

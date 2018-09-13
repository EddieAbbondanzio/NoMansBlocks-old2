using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Handles firing off event listeners for a single axis
    /// of the mouse.
    /// </summary>
    public sealed class MouseAxisHandler : IInputHandler {
        #region Properties
        /// <summary>
        /// The axis to listen for changes on.
        /// </summary>
        public MouseAxis Axis { get; }
        #endregion

        #region Members
        /// <summary>
        /// The listeners to notify anytime the axis is changed.
        /// </summary>
        private List<MouseAxisListener> listeners;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new axis handler for the passed in mouse
        /// axis. Starts off with no listeners.
        /// </summary>
        /// <param name="axis">The axis to listen for.</param>
        public MouseAxisHandler(MouseAxis axis) {
            Axis = axis;
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Update this handler using the input state poller
        /// passed in.
        /// </summary>
        /// <param name="inputPoller">The poller to check input state.</param>
        public void Update(IInputPoller inputPoller) {
            throw new NotImplementedException();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Add a new listener to the handler.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public void AddListener(MouseAxisListener listener) {
            if(listeners == null) {
                listeners = new List<MouseAxisListener>();
            }

            listeners.Add(listener);
        }

        /// <summary>
        /// Remove a specific listener from the handler.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveListener(MouseAxisListener listener) {
            if(listener != null) {
                for(int i = 0, listenerCount = listeners.Count; i < listenerCount; i++) {
                    if(listeners[i] == listener) {
                        listeners.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Remove every single listener from the handler.
        /// </summary>
        public void RemoveAllListeners() {
            listeners = null;
        }
        #endregion
    }
}

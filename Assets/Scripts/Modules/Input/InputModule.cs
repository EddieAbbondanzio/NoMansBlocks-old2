using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.Input.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input {
    /// <summary>
    /// Module that handles all of the input from the player.
    /// </summary>
    public sealed class InputModule : Module, IInputDeviceManager {
        #region Event Delegates
        /// <summary>
        /// Indicates that child devices need to perform an
        /// update and process new input.
        /// </summary>
        public event EventHandler OnDeviceUpdate;
        #endregion

        #region Members
        /// <summary>
        /// The poller for checking current input state.
        /// </summary>
        private IInputPoller inputPoller;

        /// <summary>
        /// The list of currently active input devices.
        /// </summary>
        private List<InputDevice> inputDevices;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the 
        /// </summary>
        /// <param name="engine">The parent engine instance.</param>
        public InputModule(GameEngine engine) : base(engine) {
            inputPoller = new UnityInputPoller();
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Alert all devices that they need to update.
        /// </summary>
        public override void OnUpdate() {
            if(OnDeviceUpdate != null) {
                OnDeviceUpdate(this, null);
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Get an instance of the desired input device.
        /// </summary>
        /// <typeparam name="T">The type of input device to return.</typeparam>
        /// <returns>The newly instantiated input device.</returns>
        public T GetInputDevice<T>() where T : InputDevice {
            //See if we already have one.
            if(inputDevices != null) {
                for(int i = 0, deviceCount = inputDevices.Count; i < deviceCount; i++) {
                    T inputDevice = inputDevices[i] as T;

                    if(inputDevice != null) {
                        return inputDevice;
                    }
                }
            }
            else {
                inputDevices = new List<InputDevice>();
            }

            //Need to create a new instance and give it out.
            T newDevice = Activator.CreateInstance(typeof(T), this, inputPoller) as T;
            inputDevices.Add(newDevice);

            return newDevice;
        }

        /// <summary>
        /// Close an input device and release it's resources from
        /// the game.
        /// </summary>
        /// <typeparam name="T">The type of device to remove.</typeparam>
        /// <param name="device">The device to remove.</param>
        public void CloseInputDevice<T>(T device) where T : InputDevice {
            for(int i = 0, deviceCount = inputDevices.Count; i < deviceCount; i++) {
                if((inputDevices[i] as T) == device) {
                    inputDevices.RemoveAt(i);
                    break;
                }
            }
        }
        #endregion
    }
}

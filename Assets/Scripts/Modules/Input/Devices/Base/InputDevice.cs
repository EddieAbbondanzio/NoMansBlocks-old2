using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Interface for user input interfaces to derive from.
    /// </summary>
    public abstract class InputDevice {
        #region Properties
        /// <summary>
        /// If the control is enabled and accepting input.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The manager handling the device.
        /// </summary>
        protected IInputDeviceManager DeviceManager { get; private set; }

        /// <summary>
        /// The poller to check the input state from.
        /// </summary>
        private IInputPoller InputPoller { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new base instance of an input device. The device manager
        /// needs to be passed in for updates.
        /// </summary>
        /// <param name="deviceManager">The device manager that owns this device.</param>
        /// <param name="inputPoller">The poller to check input state from.</param>
        /// <param name="enabled">If the control should start enabled or not.</param>
        protected InputDevice(IInputDeviceManager deviceManager, IInputPoller inputPoller) {
            DeviceManager = deviceManager;
            InputPoller = inputPoller;
            DeviceManager.OnDeviceUpdate += DeviceManager_OnUpdate;
            Enabled = true;
        }

        /// <summary>
        /// Free up resources.
        /// </summary>
        ~InputDevice() {
            DeviceManager.OnDeviceUpdate -= DeviceManager_OnUpdate;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Close up the device and release it's resources. This is just a shortcut
        /// to call DeviceManager.CloseInputDevice().
        /// </summary>
        public void Close() {
            DeviceManager.CloseInputDevice(this);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Update the state of the controller.
        /// </summary>
        /// <param name="inputPoller">Check current input state from.</param>
        protected abstract void Update(IInputPoller inputPoller);

        /// <summary>
        /// Called everytime the device manager wants it's devices
        /// to update. This checks that the device is enabled before firing it's
        /// inner update system.
        /// </summary>
        /// <param name="sender">The device manager.</param>
        /// <param name="e">Null.</param>
        private void DeviceManager_OnUpdate(object sender, EventArgs e) {
            if (Enabled) {
                Update(InputPoller);
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// Interface for an object that manage a collection of input
    /// devices and call their update methods.
    /// </summary>
    public interface IInputDeviceManager {
        #region Event Delegates
        /// <summary>
        /// Fired off everytime a device needs to perform
        /// an update of it's state.
        /// </summary>
        event EventHandler OnDeviceUpdate;
        #endregion

        #region Publics
        /// <summary>
        /// Get an instance of the desired input device.
        /// </summary>
        /// <typeparam name="T">The type of input device to return.</typeparam>
        /// <returns>The newly instantiated input device.</returns>
        T GetInputDevice<T>() where T : InputDevice;

        /// <summary>
        /// Close an input device and release it's resources from
        /// the game.
        /// </summary>
        /// <typeparam name="T">The type of device to remove.</typeparam>
        /// <param name="device">The device to remove.</param>
        void CloseInputDevice<T>(T device) where T : InputDevice;
        #endregion
        }
}

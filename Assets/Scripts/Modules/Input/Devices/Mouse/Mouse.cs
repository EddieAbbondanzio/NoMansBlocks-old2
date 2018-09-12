using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Input.Devices {
    ///// <summary>
    ///// The standard computer mouse.
    ///// </summary>
    //public class Mouse : InputDevice {
    //    #region Properties
    //    /// <summary>
    //    /// If the horizontal axis should be inverted.
    //    /// </summary>
    //    public bool InvertHorizontal { get; set; }

    //    /// <summary>
    //    /// If the vertical axis should be inverted.
    //    /// </summary>
    //    public bool InvertVertical { get; set; }
    //    #endregion

    //    #region Publics
    //    /// <summary>
    //    /// Checks if the mouse button is being pressed down
    //    /// this frame.
    //    /// </summary>
    //    /// <param name="button">The button to check.</param>
    //    /// <returns>True if the being clicked this frame.</returns>
    //    public bool IsButtonDown(MouseButton button) {
    //        if (Enabled) {
    //            return UnityEngine.Input.GetMouseButtonDown((int)button);
    //        }
    //        else {
    //            return false;
    //        }
    //    }

    //    /// <summary>
    //    /// Checks if the mouse button is currently pressed.
    //    /// </summary>
    //    /// <param name="button">The button to check.</param>
    //    /// <returns>True if currently clicked.</returns>
    //    public bool IsButtonPressed(MouseButton button) {
    //        if (Enabled) {
    //            return UnityEngine.Input.GetMouseButton((int)button);
    //        }
    //        else {
    //            return false;
    //        }
    //    }

    //    /// <summary>
    //    /// Checks if the mouse button is being released 
    //    /// this frame.
    //    /// </summary>
    //    /// <param name="button">The button to check.</param>
    //    /// <returns>True if being released this frame.</returns>
    //    public bool IsButtonUp(MouseButton button) {
    //        if (Enabled) {
    //            return UnityEngine.Input.GetMouseButtonUp((int)button);
    //        }
    //        else {
    //            return false;
    //        }
    //    }

    //    /// <summary>
    //    /// Get the smoothened out axis.
    //    /// </summary>
    //    /// <param name="axis">The axis of the mouse to check.</param>
    //    /// <returns>The axis from -1 to 1.</returns>
    //    public float GetAxis(MouseAxis axis) {
    //        if (Enabled) {
    //            string axisName = ConvertAxisToName(axis);
    //            float axisValue = UnityEngine.Input.GetAxis(axisName);

    //            switch (axis) {
    //                case MouseAxis.Horizontal:
    //                    return InvertHorizontal ? axisValue * -1 : axisValue;
    //                case MouseAxis.Vertical:
    //                    return InvertVertical ? axisValue * -1 : axisValue;
    //                default:
    //                    return axisValue;
    //            }
    //        }
    //        else {
    //            return 0;
    //        }
    //    }

    //    /// <summary>
    //    /// Get the raw axis.
    //    /// </summary>
    //    /// <param name="axis">The axis of the mouse to check.</param>
    //    /// <returns>The axis from -1 to 1.</returns>
    //    public float GetAxisRaw(MouseAxis axis) {
    //        if (Enabled) {
    //            string axisName = ConvertAxisToName(axis);
    //            float axisValue = UnityEngine.Input.GetAxisRaw(axisName);

    //            switch (axis) {
    //                case MouseAxis.Horizontal:
    //                    return InvertHorizontal ? axisValue * -1 : axisValue;
    //                case MouseAxis.Vertical:
    //                    return InvertVertical ? axisValue * -1 : axisValue;
    //                default:
    //                    return axisValue;
    //            }
    //        }
    //        else {
    //            return 0;
    //        }
    //    }
    //    #endregion

    //    #region Helpers
    //    /// <summary>
    //    /// Convert the mouse axis into it's unity string name.
    //    /// </summary>
    //    /// <param name="axis">The mouse axis to convert.</param>
    //    /// <returns>The string representing it's Unity counterpart.</returns>
    //    private string ConvertAxisToName(MouseAxis axis) {
    //        switch (axis) {
    //            case MouseAxis.Horizontal:
    //                return "Horizontal";
    //            case MouseAxis.Vertical:
    //                return "Vertical";
    //            case MouseAxis.ScrollWheel:
    //                return "Mouse ScrollWheel";
    //            default:
    //                throw new NotSupportedException(string.Format("Mouse Axis of {0} is not supported.", axis.ToString()));
    //        }
    //    }
    //    #endregion
    //}
}

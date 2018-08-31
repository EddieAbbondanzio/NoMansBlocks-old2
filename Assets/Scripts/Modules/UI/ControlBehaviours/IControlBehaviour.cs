using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Interface to represent the various UI controls
    /// of the engine.
    /// </summary>
    public interface IControlBehaviour {
        #region Properties
        /// <summary>
        /// The unique name of the control
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The type of control it is.
        /// </summary>
        ControlType ControlType { get; }
        #endregion
    }
}

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
    public interface IControl {
        #region Properties
        /// <summary>
        /// The unique name of the control
        /// </summary>
        string Name { get; }

        /// <summary>
        /// If the control is enabled, and accepting
        /// user input
        /// </summary>
        bool Enabled { get; set; }
        #endregion
    }
}

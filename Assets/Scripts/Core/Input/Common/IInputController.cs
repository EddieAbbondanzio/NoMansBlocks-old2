using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input {
    /// <summary>
    /// Interface for input controlelrs to derive from to ensure they
    /// follow some common functionality.
    /// </summary>
    public interface IInputController {
        #region Properties
        /// <summary>
        /// If the controller is enabled and listening
        /// for input from the user.
        /// </summary>
        bool Enabled { get; set; }
        #endregion
    }
}

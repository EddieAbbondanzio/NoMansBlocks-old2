using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input {
    /// <summary>
    /// Controller for the standard player where they are
    /// playing in a match.
    /// </summary>
    public sealed class PlayerInputController : IInputController {
        #region Properties
        /// <summary>
        /// If the controller is enabled and listening for input.
        /// </summary>
        public bool Enabled { get; set; }
        #endregion
    }
}

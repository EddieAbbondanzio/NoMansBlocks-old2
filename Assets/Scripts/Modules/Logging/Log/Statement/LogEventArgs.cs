using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Logging {
    /// <summary>
    /// Arguments for passing a log statment around.
    /// </summary>
    public sealed class LogEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The statement being passed.
        /// </summary>
        public LogStatement LogStatement { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new set of arguments.
        /// </summary>
        /// <param name="logStatement">The statement to pass around.</param>
        public LogEventArgs(LogStatement logStatement) {
            LogStatement = logStatement;
        }
        #endregion
    }
}


using System;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// Interface to represent a log message that is being
    /// written to the log file.
    /// </summary>
    public interface ILogStatement {
        #region  Properties
        /// <summary>
        /// The type of log message it is.
        /// </summary>
        LogStatementType Type { get; }

        /// <summary>
        /// When the log message was made.
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// The actual message of the log.
        /// </summary>
        string Message { get; }
        #endregion
    }
}
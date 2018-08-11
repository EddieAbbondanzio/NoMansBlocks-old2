using System;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// A log message of something that isn't serious,
    /// but is worth noting in the log file.
    /// </summary>
    public class DebugLog : ILogStatement {
        #region  Properties
        /// <summary>
        /// The type of message it is.
        /// </summary>
        public LogStatementType Type => LogStatementType.Debug;

        /// <summary>
        /// When the message was created.
        /// </summary>
        public DateTime Time { get; private set; }

        /// <summary>
        /// The actual log message
        /// </summary>
        public string Message { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new message right now.
        /// </summary>
        /// <param name="message"></param>
        public DebugLog(string message) {
            Time = DateTime.Now;
            Message = message;
        }
        #endregion
    }
}
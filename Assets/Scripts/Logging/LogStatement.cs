using Newtonsoft.Json;
using System;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// Interface to represent a log message that is being
    /// written to the log file.
    /// </summary>
    [Serializable]
    public class LogStatement {
        #region  Properties
        /// <summary>
        /// The type of log message it is.
        /// </summary>
        [JsonProperty]
        public LogStatementType Type { get; private set; }

        /// <summary>
        /// When the log message was made.
        /// </summary>
        [JsonProperty]
        public DateTime Time { get; }

        /// <summary>
        /// The actual message of the log.
        /// </summary>
        [JsonProperty]
        public string Message { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty log statement. This is used by JSON 
        /// deserialization.
        /// </summary>
        public LogStatement() {
        }

        /// <summary>
        /// Create a new log statment with a time of right now.
        /// </summary>
        /// <param name="type">What kind of log message it is.</param>
        /// <param name="message">The message of the log.</param>
        public LogStatement(LogStatementType type, string message) {
            Type = type;
            Message = message;
            Time = DateTime.Now;
        }
        #endregion
    }
}
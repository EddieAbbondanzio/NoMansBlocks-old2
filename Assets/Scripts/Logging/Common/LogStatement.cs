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
        public LogStatementType Type { get; set; }

        /// <summary>
        /// When the log message was made.
        /// </summary>
        [JsonProperty]
        public DateTime Time { get; set; }

        /// <summary>
        /// The actual message of the log.
        /// </summary>
        [JsonProperty]
        public string Message { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty log statement. This is used by JSON 
        /// deserialization.
        /// </summary>
        [JsonConstructor]
        protected LogStatement() {
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

        #region Publics
        /// <summary>
        /// Generate a user friendly string to represent the log statement.
        /// </summary>
        /// <returns>A user-readable string.</returns>
        public override string ToString() {
            return string.Format("{0} {1} {2}", Type.ToString(), Time, Message);
        }
        #endregion
    }
}
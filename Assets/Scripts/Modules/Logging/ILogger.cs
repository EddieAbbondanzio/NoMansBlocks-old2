using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Logging {
    /// <summary>
    /// Interface to represent any kind of debug logger
    /// that can provide the ability to log messages, warnings,
    /// errors, and fatal errors.
    /// </summary>
    public interface ILogger {
        #region Properties
        /// <summary>
        /// The collection of all logs made by the logger.
        /// </summary>
        List<LogStatement> History { get; }
        #endregion

        #region Events
        /// <summary>
        /// Fired off every time the logger creates a new
        /// log statement.
        /// </summary>
        event EventHandler<StatementArgs> OnLogStatementCreated;
        #endregion

        #region Publics
        /// <summary>
        /// Log a debug message to the console / file.
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        void Debug(string message);

        /// <summary>
        /// Log a debug message to the console / file. Parameters
        /// are inserted into the message using string.format().
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        void Debug(string message, params object[] parameters);

        /// <summary>
        /// Log a warning message to the console / file.
        /// </summary>
        /// <param name="message">The warning message.</param>
        void Warn(string message);

        /// <summary>
        /// Log a debug message to the console / file. Parameters
        /// are inserted into the message using string.format().
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        void Warn(string message, params object[] parameters);

        /// <summary>
        /// Log an error message to the console / file.
        /// </summary>
        /// <param name="message">The error message.</param>
        void Error(string message);

        /// <summary>
        /// Log an error message to the console / file. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        void Error(string message, params object[] parameters);

        /// <summary>
        /// Log a fatal error that will cause the program to crash.
        /// </summary>
        /// <param name="message">The message to store with it.</param>
        void Fatal(string message);

        /// <summary>
        /// Log a fatal error that will crash things. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        void Fatal(string message, params object[] parameters);
        #endregion
    }
}

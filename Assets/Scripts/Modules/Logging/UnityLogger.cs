using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Logging {
    /// <summary>
    /// Logger for running within Unity. This ties in to the Debug
    /// class offered by the UnityEngine to spit out messages to the
    /// console.
    /// </summary>
    public class UnityLogger : ILogger {
        #region Properties
        /// <summary>
        /// The collection of logs made by the logger
        /// since it started.
        /// </summary>
        public List<LogStatement> History { get; private set; }
        #endregion

        #region Events
        /// <summary>
        /// Fired everytime a log statement is made.
        /// </summary>
        public event EventHandler<StatementArgs> OnLogStatementCreated;
        #endregion

        #region Members
        /// <summary>
        /// The semaphore lock object.
        /// </summary>
        private readonly object lockObj;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new Unity Console logger.
        /// </summary>
        public UnityLogger() {
            History = new List<LogStatement>();
            lockObj = new object();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Log a debug message to the console / file.
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        public void Debug(string message) {
            LogStatement logStatement = new LogStatement(LogStatementType.Debug, message);

            lock (lockObj) {
                UnityEngine.Debug.Log(message);
                History.Add(logStatement);
            }

            //Fire off the event
            if(OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log a debug message to the console / file. Parameters
        /// are inserted into the message using string.format().
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public void Debug(string message, params object[] parameters) {
            string fullMessage = string.Format(message, parameters);
            LogStatement logStatement = new LogStatement(LogStatementType.Debug, fullMessage);

            lock (lockObj) {
                UnityEngine.Debug.Log(fullMessage);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log a warning message to the console / file.
        /// </summary>
        /// <param name="message">The warning message.</param>
        public void Warn(string message) {
            LogStatement logStatement = new LogStatement(LogStatementType.Warning, message);

            lock (lockObj) {
                UnityEngine.Debug.LogWarning(message);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log a warning message to the console / file. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <param name="parameters">The objects to insert into the warning.</param>
        public void Warn(string message, params object[] parameters) {
            string fullMessage = string.Format(message, parameters);
            LogStatement logStatement = new LogStatement(LogStatementType.Warning, fullMessage);

            lock (lockObj) {
                UnityEngine.Debug.LogWarning(fullMessage);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log an error message to the console / file.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void Error(string message) {
            LogStatement logStatement = new LogStatement(LogStatementType.Error, message);

            lock (lockObj) {
                UnityEngine.Debug.LogError(message);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log an error message to the console / file. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public void Error(string message, params object[] parameters) {
            string fullMessage = string.Format(message, parameters);
            LogStatement logStatement = new LogStatement(LogStatementType.Error, fullMessage);

            lock (lockObj) {
                UnityEngine.Debug.LogError(fullMessage);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log an exception to the console / file.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        public void Error(Exception exception) {
            string exceptionString = exception.ToString();
            LogStatement logStatement = new LogStatement(LogStatementType.Error, exceptionString);

            lock (lockObj) {
                UnityEngine.Debug.LogError(exceptionString);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log a fatal error that will cause the program to crash.
        /// </summary>
        /// <param name="message">The message to store with it.</param>
        public void Fatal(string message) {
            LogStatement logStatement = new LogStatement(LogStatementType.Fatal, message);

            lock (lockObj) {
                UnityEngine.Debug.LogError(message);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }

        /// <summary>
        /// Log a fatal error that will crash things. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public void Fatal(string message, params object[] parameters) {
            string fullMessage = string.Format(message, parameters);
            LogStatement logStatement = new LogStatement(LogStatementType.Fatal, message);

            lock (lockObj) {
                UnityEngine.Debug.LogError(fullMessage);
                History.Add(logStatement);
            }

            //Fire off the event
            if (OnLogStatementCreated != null) {
                OnLogStatementCreated(this, new StatementArgs(logStatement));
            }
        }
        #endregion
    }
}

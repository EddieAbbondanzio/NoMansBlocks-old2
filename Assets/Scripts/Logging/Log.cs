using NoMansBlocks.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Serialization;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// Logger for printing out debugs, warnings,
    /// and more to the console along with generating 
    /// log files automatically.
    /// </summary>
    public static class Log {
        #region Constants
        /// <summary>
        /// The directory where to store log files.
        /// </summary>
        public const string LogDirectoryName = "Logs";

        /// <summary>
        /// The maximum number of log files that can exist in the log 
        /// directory at any time.
        /// </summary>
        public const int LogDirectoryCapacity = 16;
        #endregion

        #region Properties
        /// <summary>
        /// The logger that actually prints the messages to console.
        /// </summary>
        private static ILogger Logger { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Called when Log is first accessed. This initializes resources needed.
        /// </summary>
        static Log() {
            //Subscribe to when things shut down to save the log file
            //Engine.OnStop += async (sender, e) => await OnEngineStop(sender, e);
        }
        #endregion

        #region Publics
        /// <summary>
        /// Set the underlying logger to use. This only
        /// sets the logger if it is already null.
        /// </summary>
        /// <param name="logger">The logger to use.</param>
        public static void SetLogger(ILogger logger) {
            if(logger != null) {
               Logger = logger;
            }
        }

        /// <summary>
        /// Log a debug message to the console / file.
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        public static void Debug(string message) {
            Logger.Debug(message);
        }

        /// <summary>
        /// Log a debug message to the console / file. Parameters
        /// are inserted into the message using string.format().
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public static void Debug(string message, params object[] parameters) {
            Logger.Debug(message, parameters);

        }

        /// <summary>
        /// Log a warning message to the console / file.
        /// </summary>
        /// <param name="message">The warning message.</param>
        public static void Warn(string message) {
            Logger.Warn(message);
        }

        /// <summary>
        /// Log a warning message to the console / file. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <param name="parameters">The objects to insert into the warning.</param>
        public static void Warn(string message, params object[] parameters) {
            Logger.Warn(message, parameters);

        }

        /// <summary>
        /// Log an error message to the console / file.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void Error(string message) {
            Logger.Error(message);
        }

        /// <summary>
        /// Log an error message to the console / file. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public static void Error(string message, params object[] parameters) {
            Logger.Error(message, parameters);
        }

        /// <summary>
        /// Log a fatal error that will cause the program to crash.
        /// </summary>
        /// <param name="message">The message to store with it.</param>
        public static void Fatal(string message) {
            Logger.Fatal(message);
        }

        /// <summary>
        /// Log a fatal error that will crash things. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public static void Fatal(string message, params object[] parameters) {
            Logger.Fatal(message, parameters);
        }
        #endregion
    }
}

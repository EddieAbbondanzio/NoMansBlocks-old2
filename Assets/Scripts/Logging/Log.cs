using NoMansBlocks.Core;
using NoMansBlocks.FileSystem;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// The growing log history. This gets dumped to a file when closing the app.
        /// </summary>
        public static List<LogStatement> History { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Called when Log is first accessed. This initializes resources needed.
        /// </summary>
        static Log() {
            History = new List<LogStatement>();

            //Subscribe to when things shut down to save the log file
            Engine.OnStop += async (sender, e) => await OnEngineStop(sender, e);
        }
        #endregion

        #region Publics
        /// <summary>
        /// Log a debug message to the console / file.
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        public static void Debug(string message) {
            LogStatement logStatement = new LogStatement(LogStatementType.Debug, message);

            UnityEngine.Debug.Log(message);
            History.Add(logStatement);
        }

        /// <summary>
        /// Log a debug message to the console / file. Parameters
        /// are inserted into the message using string.format().
        /// </summary>
        /// <param name="message">The debug message to print.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public static void Debug(string message, params object[] parameters) {
            string fullMessage = string.Format(message, parameters);
            LogStatement logStatement = new LogStatement(LogStatementType.Debug, fullMessage);

            UnityEngine.Debug.Log(fullMessage);
            History.Add(logStatement);
        }

        /// <summary>
        /// Log a warning message to the console / file.
        /// </summary>
        /// <param name="message">The warning message.</param>
        public static void Warn(string message) {
            LogStatement logStatement = new LogStatement(LogStatementType.Warning, message);

            UnityEngine.Debug.LogWarning(message);
            History.Add(logStatement);
        }

        /// <summary>
        /// Log a warning message to the console / file. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <param name="parameters">The objects to insert into the warning.</param>
        public static void Warn(string message, params object[] parameters) {
            string fullMessage = string.Format(message, parameters);
            LogStatement logStatement = new LogStatement(LogStatementType.Warning, fullMessage);

            UnityEngine.Debug.LogWarning(fullMessage);
            History.Add(logStatement);
        }

        /// <summary>
        /// Log an error message to the console / file.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void Error(string message) {
            LogStatement logStatement = new LogStatement(LogStatementType.Error, message);

            UnityEngine.Debug.LogError(message);
            History.Add(logStatement);
        }

        /// <summary>
        /// Log an error message to the console / file. Parameters
        /// are inserted into the message using string.Format().
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="parameters">The objects to insert into the message.</param>
        public static void Error(string message, params object[] parameters) {
            string fullMessage = string.Format(message, parameters);
            LogStatement logStatement = new LogStatement(LogStatementType.Error, fullMessage);

            UnityEngine.Debug.LogError(fullMessage);
            History.Add(logStatement);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// When things shut down we build the log file.
        /// </summary>
        /// <param name="sender">(Engine.cs)</param>
        /// <param name="e">Always null</param>
        private static async Task OnEngineStop(object sender, EventArgs e) {
            //Don't save unless we have logged anything
            if(History.Count == 0) {
                return;
            }

            DirectoryInfo logDirectory = DirectoryIO.FromLocalPath(LogDirectoryName);

            //Make sure it exists.
            if (!logDirectory.Exists) {
                logDirectory.Create();
            }

            //Generate a timestamp log file name.
            string logFileName = string.Format("{0}.log", DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"));

            //Build the actual file.
            FileInfo fileInfo = FileIO.FromLocalPath(LogDirectoryName, logFileName);
            LogFile logFile = new LogFile(fileInfo, History);

            try {
                await FileIO.SaveAsync(logFile);

                //See if we need to trim the directory at all
                if (logDirectory.FileCount() > LogDirectoryCapacity) {
                    DirectoryIO.Shrink(logDirectory, LogDirectoryCapacity);
                }
            }
            catch(Exception exception) {
                //Not really sure what to do when saving the log file fails...
                Error(exception.ToString());
            }
        }
        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using NoMansBlocks.Core;
using NoMansBlocks.FileSystem;
using UnityEngine;

namespace NoMansBlocks.Utils {
    /// <summary>
    /// Logger utils that build a log file as well.
    /// </summary>
    public static class LogUtils {
        #region Properties
        /// <summary>
        /// The list of logs that have been made since the program
        /// started running.
        /// </summary>
        public static List<string> History { get; private set; }
        #endregion

        #region Constructor(s)
        static LogUtils() {
            //Subscribe to the on stop event
            if (Engine.Instance != null) {
                Engine.Instance.OnStop += OnStop;
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Log a formatted message to the console. This is meant
        /// for debugging purposes or non serious messages.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="parameters">Any parameters associated with it.</param>
        public static void Log(string message, params object[] parameters) {
            string formattedMsg = string.Format(message, parameters);
            Debug.Log(formattedMsg);
        }

        /// <summary>
        /// Log a formatted warning to the console. This is for
        /// messages that should be looked into, but aren't fatal.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="parameters">Any parameters to format into it.</param>
        public static void LogWarning(string message, params object[] parameters) {
            string formattedMsg = string.Format(message, parameters);
            Debug.LogWarning(formattedMsg);
        }

        /// <summary>
        /// Log an error to the console. This is for fatal errors
        /// that must be dealt with.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="parameters">Any parameters to format into it.</param>
        public static void LogError(string message, params object[] parameters) {
            string formattedMsg = string.Format(message, parameters);
            Debug.LogError(formattedMsg);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Cleans things up and writes the log file to file.
        /// </summary>
        /// <param name="sender">The sender (Engine)</param>
        /// <param name="e">Always null</param>
        private static void OnStop(object sender, EventArgs e) {
            //Don't bother unless we have anything to write.
            if (History?.Count > 0) {
                LogFile logFile = new LogFile("test", History);
            }

            Engine.Instance.OnStop -= OnStop;
        }
        #endregion
    }
}
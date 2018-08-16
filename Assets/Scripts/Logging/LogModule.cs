using NoMansBlocks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// Module to perform all logging related functions. Ensures we
    /// take a snap shot of the system, along with managing log files
    /// and more. This module can be accessed at any time by using
    /// the static Log interface.
    /// </summary>
    public class LogModule : Module {
        #region Properties
        /// <summary>
        /// The logger being used in the Log.cs class.
        /// </summary>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// Analyzes the system and collects some meta info.
        /// </summary>
        public SystemAnalyzer SystemAnalyzer { get; private set; }

        /// <summary>
        /// Handles loading and saving logs to file.
        /// </summary>
        public LogFileHandler LogFileHandler { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Initialize a new log module for use.
        /// </summary>
        public LogModule() {
            Logger         = new UnityLogger();
            SystemAnalyzer = new SystemAnalyzer();
            LogFileHandler = new LogFileHandler();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Initialize the logger for use.
        /// </summary>
        public override void OnInit() {
            Log.SetLogger(Logger);
        }

        /// <summary>
        /// When things are shutting down send the
        /// log report off to be saved to file.
        /// </summary>
        public override void OnEnd() {
            LogReport logReport = new LogReport(SystemAnalyzer.GetSystemInfo(), Logger.History);
            Task.Run(async () => { await LogFileHandler.SaveLog(logReport); });
        }
        #endregion
    }
}

using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Logging {
    /// <summary>
    /// Module to perform all logging related functions. Ensures we
    /// take a snap shot of the system, along with managing log files
    /// and more. This module can be accessed at any time by using
    /// the static Log interface.
    /// </summary>
    public sealed class LogModule : Module {
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
        /// <paramref name="engine">The engine that owns the module.</paramref>
        /// </summary>
        /// <param name="engine">The parent game engine.</param>
        public LogModule(GameEngine engine, ILogger logger) : base(engine) {
            Logger         = logger;
            SystemAnalyzer = new SystemAnalyzer();
            LogFileHandler = new LogFileHandler();
        }
        #endregion

        #region Module Events
        /// <summary>
        /// Initialize the logger for use.
        /// </summary>
        public override void OnInit() {
            Log.SetLogger(Logger);
            Engine.Context.OnUnhandledException += OnUnhandledException;
        }

        /// <summary>
        /// When things are shutting down send the
        /// log report off to be saved to file.
        /// </summary>
        public override void OnEnd() {
            LogReport logReport = new LogReport(SystemAnalyzer.GetSystemInfo(), Logger.History);
            string logFileName = string.Format("{0}.log", DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"));

            //Create and save the file.
            LogFile logFile = LogFileHandler.Create(logFileName, logReport);
            Task.Run(async () => { await LogFileHandler.SaveAsync(logFile); });
            Engine.Context.OnUnhandledException -= OnUnhandledException;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Processess an unhandled exception by logging it before things crash.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Exception exception = e.ExceptionObject as Exception;
            Log.Fatal(exception.ToString());
        }
        #endregion
    }
}

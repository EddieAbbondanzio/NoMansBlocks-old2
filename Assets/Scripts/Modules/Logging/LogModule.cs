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
    public sealed class LogModule : Module, IStatementProducer {
        #region Properties
        /// <summary>
        /// Indicator for the IStatementProducer interface to flag what
        /// kind of statements this module produces.
        /// </summary>
        public StatementType StatementType => StatementType.Log;

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

        #region Events
        /// <summary>
        /// Fired whenever a new log statement is made.
        /// </summary>
        public event EventHandler<StatementArgs> OnStatementCreated;
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

            //Subscribe to the logger event
            Logger.OnLogStatementCreated += OnLogStatementCreated;
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

            //Remove the logger event to prevent memory leaks.
            Logger.OnLogStatementCreated -= OnLogStatementCreated;
        }
        #endregion

        #region Component Events
        /// <summary>
        /// Fired off whenever the logger creates a new log
        /// message.
        /// </summary>
        /// <param name="sender">The logger that created the log.</param>
        /// <param name="e">Arguments containing the log message.</param>
        private void OnLogStatementCreated(object sender, StatementArgs e) {
            //Propogate the event further if any listeners exist outside of this module.
            if(OnStatementCreated != null) {
                OnStatementCreated(this, e);
            }
        }
        #endregion
    }
}

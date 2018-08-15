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
    /// and more.
    /// </summary>
    public class LogModule : BaseModule {
        #region Properties
        /// <summary>
        /// The logger being used in the Log.cs class.
        /// </summary>
        public ILogger Logger { get; private set; }
        #endregion

        #region Publics
        /// <summary>
        /// Initialize the logger for use.
        /// </summary>
        public override void OnInit() {
            Logger = new UnityLogger();
            Log.SetLogger(Logger);
        }

        /// <summary>
        /// When things are shutting down send the
        /// log report off to be saved to file.
        /// </summary>
        public override void OnEnd() {

        }
        #endregion
    }
}

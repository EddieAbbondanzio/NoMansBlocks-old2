using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// A log report attempts to build a snap-shot of the current
    /// state of everything for chasing down errors later on.
    /// </summary>
    [Serializable]
    public class LogReport {
        #region Properties
        /// <summary>
        /// The log messages of the report.
        /// </summary>
        [JsonProperty]
        public List<LogStatement> Logs { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Build a new log report.
        /// </summary>
        /// <param name="logs">The logs of the report.</param>
        public LogReport(List<LogStatement> logs) {
            Logs = logs;
        }
        
        /// <summary>
        /// Used to de-serialize reports from file.
        /// </summary>
        [JsonConstructor]
        protected LogReport() {
        }
        #endregion
    }
}

using NoMansBlocks.Core.FileIO;
using NoMansBlocks.Core.Serialization;
using NoMansBlocks.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Logging {
    /// <summary>
    /// A log file contains a collection of logs, and more
    /// to help tracing down issues that may arise.
    /// </summary>
    public class LogFile : JsonFile<LogReport> {
        #region Constructor(s)
        /// <summary>
        /// Create a new empty log file.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        public LogFile(FileInfo info) : base(info) {
        }

        /// <summary>
        /// Create a new log file using the report passed in.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        /// <param name="report">The log report to store in the file.</param>
        public LogFile(FileInfo info, LogReport report) : base (info, report) {
        }

        /// <summary>
        /// Deserialize a log file from disk.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        /// <param name="content">The raw content of the file.</param>
        public LogFile(FileInfo info, byte[] content) : base(info, content) {
        }
        #endregion
    }
}

using NoMansBlocks.Core.FileIO;
using NoMansBlocks.Core.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Logging {
    /// <summary>
    /// Manages FileIO for saving log files to their
    /// respective directory.
    /// </summary>
    public class LogFileHandler : FileHandler<LogFile> {
        #region Properties
        /// <summary>
        /// The directory to store the log files under.
        /// </summary>
        public override string Directory => "Logs";

        /// <summary>
        /// The maximum number of log files in the log directory.
        /// </summary>
        public override int Capacity => 16;
        #endregion
    }
}

using NoMansBlocks.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// Manages FileIO for saving log files to their
    /// respective directory.
    /// </summary>
    public class LogFileHandler {
        #region Constants
        /// <summary>
        /// The directory to store log files under.
        /// </summary>
        public const string Directory = "Logs";

        /// <summary>
        /// The maximum number of log files that is okay
        /// to keep in the directory at any time.
        /// </summary>
        public const int Capacity = 16;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new Log File Handler for 
        /// managing .log files.
        /// </summary>
        public LogFileHandler() {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Save a log report to file. The current timestamp is used
        /// as the file name.
        /// </summary>
        /// <param name="report">The log report to save.</param>
        public async Task<bool> SaveLog(LogReport report) {
            DirectoryInfo logDirectory = FileSystem.ResolveDirectoryPath(Directory);

            //Create the directory if it doesn't exist.
            if(!logDirectory.Exists) {
                logDirectory.Create();
            }

            try {
                //Create the file info.
                string logFileName = string.Format("{0}.log", DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"));
                FileInfo fileInfo = FileSystem.ResolveFilePath(Directory, logFileName);

                //Now make the file
                LogFile logFile = new LogFile(fileInfo, report);
                await FileSystem.SaveAsync(logFile);

                //See if we need to trim the directory at all
                if (logDirectory.FileCount() > Capacity) {
                    FileSystem.ShrinkDirectory(logDirectory, Capacity);
                }

                return true;
            }
            catch(Exception) {
                return false;
            }
        }
        #endregion
    }
}

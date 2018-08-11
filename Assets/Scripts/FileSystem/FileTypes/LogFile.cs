
using System.Collections.Generic;
using System.Text;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// A log file is a file that contains a shit ton of
    /// text in it describing what exactly went wrong.
    /// </summary>
    public class LogFile : IFile {
        #region Properties
        /// <summary>
        /// The type of file it is.
        /// </summary>
        public FileType Type => FileType.Log;

        /// <summary>
        /// The path, name, and extension of the file.
        /// </summary>
        /// <value></value>
        public FileInfo Info { get; set; }

        /// <summary>
        /// The log messages stored in this file
        /// </summary>
        public List<string> LogMessages { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new log file with the name
        /// passed in.
        /// </summary>
        /// <param name="name">The name of the file. Exclude the extension.</param>
        /// <param name="logMessages">The list of logs to store in it.</param>
        public LogFile(string name, List<string> logMessages) {
            // Name = name;
            LogMessages = logMessages;
        }
        #endregion

    }
}
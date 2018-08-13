using NoMansBlocks.Logging;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        public FileInfo Info { get; private set; }

        /// <summary>
        /// The log messages stored in this file
        /// </summary>
        public List<LogStatement> Content { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new log file with the name
        /// passed in.
        /// </summary>
        /// <param name="fileInfo">The path of the file.</param>
        /// <param name="content">The list of logs to store in it.</param>
        public LogFile(FileInfo fileInfo, List<LogStatement> content) {
            Info = fileInfo;
            Content = content;
        }
        #endregion
    }
}
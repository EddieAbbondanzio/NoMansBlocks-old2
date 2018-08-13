using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// A standard text file.
    /// </summary>
    public class TextFile : IFile {
        #region Properties
        /// <summary>
        /// The type of file it is.
        /// </summary>
        public FileType Type => FileType.Text;

        /// <summary>
        /// The info pertaining to file path,
        /// name, and extension.
        /// </summary>
        public FileInfo Info { get; private set; }

        /// <summary>
        /// The actual content of the file.
        /// </summary>
        public string Content { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new text file with the following content.
        /// </summary>
        /// <param name="fileInfo">The path where the file resides (or will reside).</param>
        /// <param name="content">The text to put in the file itself.</param>
        public TextFile(FileInfo fileInfo, string content) {
            if(fileInfo.GetFileType() != FileType.Text) {
                throw new ArgumentException(string.Format("Invalid file extension of {0}", fileInfo.Extension));
            }

            Info = Info;
            Content = content;
        }
        #endregion
    }
}

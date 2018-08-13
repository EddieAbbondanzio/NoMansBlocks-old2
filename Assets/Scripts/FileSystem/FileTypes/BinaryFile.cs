using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// A Binary file is one that contains raw bytes 
    /// within it.
    /// </summary>
    public class BinaryFile : IFile {
        #region Properties
        /// <summary>
        /// The type of file it is.
        /// </summary>
        public FileType Type => FileType.Binary;

        /// <summary>
        /// The info pertaining to file path, name,
        /// and extension.
        /// </summary>
        public FileInfo Info { get; private set; }
    
        /// <summary>
        /// The bytes of the file
        /// </summary>
        public byte[] Content { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new binary file
        /// </summary>
        /// <param name="fileInfo">The path of the file.</param>
        /// <param name="content">The content within the file.</param>
        public BinaryFile(FileInfo fileInfo, byte[] content) {
            Info = Info;
            Content = content;
        }
        #endregion
    }
}

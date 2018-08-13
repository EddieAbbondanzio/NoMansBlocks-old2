using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// A file that contains data in the form of JSON.
    /// </summary>
    public class JsonFile : IFile {
        #region Properties
        /// <summary>
        /// The type of file it is.
        /// </summary>
        public FileType Type => FileType.Json;

        /// <summary>
        /// The info pertaining to file path, name,
        /// and extension.
        /// </summary>
        public FileInfo Info { get; private set; }

        /// <summary>
        /// The content of the file.
        /// </summary>
        public JObject Content { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new JSON file with the following
        /// content.
        /// </summary>
        /// <param name="fileInfo">The info aboutthe file.</param>
        /// <param name="content">The content to store in
        /// the file.</param>
        public JsonFile(FileInfo fileInfo, JObject content) {
            if (fileInfo.GetFileType() != FileType.Json) {
                throw new ArgumentException(string.Format("Invalid file extension of {0}", fileInfo.Extension));
            }

            Info = fileInfo;
            Content = content;
        }
        #endregion
    }
}
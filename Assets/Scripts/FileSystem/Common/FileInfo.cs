
using System.IO;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// The less important info about a file such as its
    /// name, path, and extension.
    /// </summary>
    public class FileInfo {
        #region Properties
        /// <summary>
        /// The path of where the file resides.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The actual files name (excludes extension)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The extension of the file (The value after .) 
        /// in the filePath.
        /// </summary>
        public string Extension { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create an empty FileInfo
        /// </summary>
        public FileInfo() {
        }

        /// <summary>
        /// Create a new file info with the
        /// name of the file specified.
        /// </summary>
        /// <param name="filePath">The file's full path.</param>
        public FileInfo(string filePath) {
            Path = filePath;
            Name = System.IO.Path.GetFileName(filePath);
            Extension = System.IO.Path.GetExtension(filePath).TrimStart('.');
        }
        #endregion

        #region Publics
        /// <summary>
        /// Determines the files type based off the
        /// extension of the path.
        /// </summary>
        /// <returns></returns>
        public FileType GetFileType() {
            switch (Extension) {
                case "bin":
                    return FileType.Binary;
                case "txt":
                    return FileType.Text;
                case "json":
                    return FileType.Json;
                case "log":
                    return FileType.Log;
                default:
                    return FileType.Unknown;
            }
        }
        #endregion
    }
}
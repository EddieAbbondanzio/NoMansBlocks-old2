using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoMansBlocks.Core.FileIO {
    /// <summary>
    /// Extensions for the FileInfo class.
    /// </summary>
    public static class FileInfoExtensions {
        /// <summary>
        /// Determines the files type based off the
        /// extension of the path.
        /// </summary>
        /// <returns></returns>
        public static FileType GetFileType(this FileInfo file) {
            switch (file.Extension) {
                case ".bin":
                    return FileType.Binary;
                case ".txt":
                    return FileType.Text;
                case ".json":
                    return FileType.Json;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

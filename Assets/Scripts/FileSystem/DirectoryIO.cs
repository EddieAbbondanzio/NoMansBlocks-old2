using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Wrapper for various functions pertaining to directories
    /// on the disk.
    /// </summary>
    public static class DirectoryIO {
        #region Statics
        /// <summary>
        /// Delete the oldest files in the directory if there is more than the 
        /// allowed capacity.
        /// </summary>
        /// <param name="directory">The directory to delete from.</param>
        /// <param name="capacity">The max amount of files allowed in the directory.</param>
        public static void Shrink(DirectoryInfo directory, int capacity) {
            FileInfo[] files = directory?.GetFiles();

            //Only do anything when the directory has too many files.
            if((files?.Length ?? 0) > capacity) {
                files = files.OrderBy(p => p.CreationTime).ToArray();

                int trimCount = files.Length - capacity;
                for(int i = 0; i < trimCount; i++) {
                    files[i].Delete();
                }
            }
        }

        /// <summary>
        /// Build a directory info from a local path string. This assumes the local
        /// path resides under the currently executing codes directory.
        /// </summary>
        /// <param name="localPath">The local path.</param>
        /// <returns>The full resolved directory info.</returns>
        public static DirectoryInfo FromLocalPath(string localPath) {
            string path = Path.Combine(Environment.CurrentDirectory, localPath);
            return new DirectoryInfo(path);
        }
        #endregion
    }
}

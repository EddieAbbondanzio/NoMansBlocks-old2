using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Handler for loading and saving Binary files to
    /// and fro Disk.
    /// </summary>
    public class BinaryFileHandler : FileHandler {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it can handle.
        /// </summary>
        public override FileType FileType => FileType.Binary;

        /// <summary>
        /// The file extension that this handler supports.
        /// </summary>
        public override string FileExtension => "bin";
        #endregion

        #region Helpers
        /// <summary>
        /// Load a Binary file from the disk.
        /// </summary>
        /// <param name="fileInfo">The path of where to load the
        /// file from.</param>
        /// <returns>The loaded JSON file.</returns>
        protected override async Task<IFile> LoadAsync(FileInfo fileInfo) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save a Binary file to disk.
        /// </summary>
        /// <param name="filePath">The path of where to save the file to.</param>
        /// <param name="file">The JSON based file to save.</param>
        protected override async Task SaveAsync(IFile file) {
            throw new NotImplementedException();
        }
        #endregion
    }
}

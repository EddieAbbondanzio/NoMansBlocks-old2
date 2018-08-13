using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Handler for loading and saving Binary files to
    /// and fro Disk.
    /// </summary>
    public class BinaryFileHandler : FileHandler<BinaryFile> {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it can handle.
        /// </summary>
        public override FileType FileType => FileType.Binary;
        #endregion

        #region Helpers
        /// <summary>
        /// Load a Binary file from the disk.
        /// </summary>
        /// <param name="fileInfo">The path of where to load the
        /// file from.</param>
        /// <returns>The loaded JSON file.</returns>
        protected override async Task<BinaryFile> LoadAsync(FileInfo fileInfo) {
            byte[] fileContent = await base.ReadFromFileAsync(fileInfo);
            return new BinaryFile(fileInfo, fileContent);
        }

        /// <summary>
        /// Save a Binary file to disk.
        /// </summary>
        /// <param name="filePath">The path of where to save the file to.</param>
        /// <param name="file">The JSON based file to save.</param>
        protected override async Task SaveAsync(BinaryFile file) {
            await base.WriteToFileAsync(file.Info, file.Content);
        }
        #endregion
    }
}

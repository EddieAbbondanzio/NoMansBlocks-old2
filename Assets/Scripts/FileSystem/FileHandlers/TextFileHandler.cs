using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Handler for loading and saving TEXT based files
    /// to and fro the disk. This uses UTF8 encoding by default.
    /// </summary>
    public class TextFileHandler : FileHandler<TextFile> {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it can handle.
        /// </summary>
        public override FileType FileType => FileType.Text;

        /// <summary>
        /// The encoding that will be used for saving and loading
        /// text files.
        /// </summary>
        public Encoding Encoding { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new UTF8 based Text File Handler.
        /// </summary>
        public TextFileHandler() {
            Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// Create a Text File Handler with a custom encoding.
        /// </summary>
        /// <param name="encoding">The encoding format to use.</param>
        public TextFileHandler(Encoding encoding) {
            Encoding = encoding;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Load a JSON file from the disk.
        /// </summary>
        /// <param name="fileInfo">The path of where to load the
        /// file from.</param>
        /// <returns>The loaded JSON file.</returns>
        protected override async Task<TextFile> LoadAsync(FileInfo fileInfo) {
            byte[] fileContent = await base.ReadFromFileAsync(fileInfo);
            string text = Encoding.GetString(fileContent);
            return new TextFile(fileInfo, text);
        }

        /// <summary>
        /// Save a JSON file to disk.
        /// </summary>
        /// <param name="filePath">The path of where to save the file to.</param>
        /// <param name="file">The JSON based file to save.</param>
        protected override async Task SaveAsync(TextFile file) {
            //Get the raw data of the content
            byte[] rawBytes = Encoding.GetBytes(file.Content);
            await base.WriteToFileAsync(file.Info, rawBytes);
        }
        #endregion
    }
}

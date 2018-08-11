using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Handler for loading and saving TEXT based files
    /// to and fro the disk. This uses UTF8 encoding by default.
    /// </summary>
    public class TextFileHandler : FileHandler {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it can handle.
        /// </summary>
        public override FileType FileType => FileType.Text;

        /// <summary>
        /// The file extension that this handler supports.
        /// </summary>
        public override string FileExtension => "txt";

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
        protected override async Task<IFile> LoadAsync(FileInfo fileInfo) {
            using (FileStream fileStream = new FileStream(fileInfo.Path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true)) {
                StringBuilder stringBuilder = new StringBuilder();
                byte[] byteBuffer = new byte[4096];
                int readCount;

                while((readCount = await fileStream.ReadAsync(byteBuffer, 0, byteBuffer.Length)) != 0) {
                    string text = Encoding.GetString(byteBuffer, 0, readCount);
                    stringBuilder.Append(text);
                }

                return new TextFile(fileInfo, stringBuilder.ToString());
            }
        }

        /// <summary>
        /// Save a JSON file to disk.
        /// </summary>
        /// <param name="filePath">The path of where to save the file to.</param>
        /// <param name="file">The JSON based file to save.</param>
        protected override async Task SaveAsync(IFile file) {
            TextFile textFile = file as TextFile;

            //Get the raw data of the content
            byte[] rawBytes = Encoding.GetBytes(textFile.Content);

            //Now actually write it
            using (FileStream fileStream = new FileStream(file.Info.Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 4096, true)) {
                await fileStream.WriteAsync(rawBytes, 0, rawBytes.Length);
            }
        }
        #endregion
    }
}

using System;
using System.IO;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Wrapper for interacting with files on the
    /// hard drive. This provides a mean
    /// </summary>
    public static class FileIO {
        #region Properties
        /// <summary>
        /// The .bin file handler
        /// </summary>
        public static BinaryFileHandler BinaryFileHandler { get; private set; }

        /// <summary>
        /// The .txt file handler
        /// </summary>
        public static TextFileHandler TextFileHandler { get; private set; }

        /// <summary>
        /// The .json file handler.
        /// </summary>
        public static JsonFileHandler JsonFileHandler { get; private set; }

        /// <summary>
        /// The current directory of where the code is running from.
        /// </summary>
        public static string CurrentDirectory { get { return Environment.CurrentDirectory; } }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Called when the FileSystem is first accessed.
        /// </summary>
        static FileIO() {
            BinaryFileHandler = new BinaryFileHandler();
            JsonFileHandler = new JsonFileHandler();
            TextFileHandler = new TextFileHandler();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load a file from the path specified.
        /// </summary>
        /// <param name="fileInfo">The path of the file</param>
        /// <typeparam name="T">The type of file to treat it as</typeparam>
        /// <returns>The loaded file</returns>
        /// <exception cref="InvalidOperationException">When the file type is unrecognized.</exception>
        public static async Task<IFile> LoadAsync(FileInfo fileInfo) {
            switch (fileInfo.GetFileType()) {
                case FileType.Binary:
                    return await BinaryFileHandler.LoadFileAsync(fileInfo);
                case FileType.Text:
                    return await TextFileHandler.LoadFileAsync(fileInfo);
                case FileType.Json:
                    return await JsonFileHandler.LoadFileAsync(fileInfo);
                default:
                    throw new InvalidOperationException(string.Format("FileType: {0} is not supported.", fileInfo.Extension));
            }
        }

        /// <summary>
        /// Save a file to disk. The file is saved at the location
        /// specified.
        /// </summary>
        /// <param name="file">The actual file to save.</param>
        public static async Task SaveAsync(IFile file) {
            switch (file.Type) {
                case FileType.Binary:
                    await BinaryFileHandler.SaveFileAsync(file);
                    break;
                case FileType.Text:
                    await TextFileHandler.SaveFileAsync(file);
                    break;
                case FileType.Json:
                    await JsonFileHandler.SaveFileAsync(file);
                    break;
                default:
                    throw new InvalidOperationException(string.Format("FileType: {0} is not supported.", file.Type));
            }
        }
        #endregion
    }
}
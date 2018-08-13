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
        /// The .log file handler
        /// </summary>
        public static LogFileHandler LogFileHandler { get; private set; }

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
            JsonFileHandler   = new JsonFileHandler();
            TextFileHandler   = new TextFileHandler();
            LogFileHandler    = new LogFileHandler();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load a file from the path specified.
        /// </summary>
        /// <typeparam name="T">The type of file to treat it as.</typeparam>
        /// <param name="filePath">The path of where the file is.</param>
        /// <returns>The loaded file.</returns>
        /// <exception cref="ArgumentNullException">If no filePath is passed in.</exception>
        /// <exception cref="FileNotFoundException">If the file doesn't actually exist.</exception>
        /// <exception cref="InvalidOperationException">When the file type is unrecognized.</exception>
        public static async Task<T> LoadAsync<T>(string filePath) where T : class, IFile {
            return await LoadAsync<T>(new FileInfo(filePath));
        }

        /// <summary>
        /// Load a file from the path specified.
        /// </summary>
        /// <typeparam name="T">The type of file to treat it as</typeparam>
        /// <param name="fileInfo">The path of the file</param>
        /// <returns>The loaded file</returns>
        /// <exception cref="ArgumentNullException">If no fileInfo is passed in.</exception>
        /// <exception cref="FileNotFoundException">If the file doesn't actually exist.</exception>
        /// <exception cref="InvalidOperationException">When the file type is unrecognized.</exception>
        public static async Task<T> LoadAsync<T>(FileInfo fileInfo) where T : class, IFile {
            switch (fileInfo.GetFileType()) {
                case FileType.Binary:
                    return await BinaryFileHandler.LoadFileAsync(fileInfo) as T;
                case FileType.Text:
                    return await TextFileHandler.LoadFileAsync(fileInfo) as T;
                case FileType.Json:
                    return await JsonFileHandler.LoadFileAsync(fileInfo) as T;
                case FileType.Log:
                    return await LogFileHandler.LoadFileAsync(fileInfo) as T;
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
                    await BinaryFileHandler.SaveFileAsync(file as BinaryFile);
                    break;
                case FileType.Text:
                    await TextFileHandler.SaveFileAsync(file as TextFile);
                    break;
                case FileType.Json:
                    await JsonFileHandler.SaveFileAsync(file as JsonFile);
                    break;
                case FileType.Log:
                    await LogFileHandler.SaveFileAsync(file as LogFile);
                    break;
                default:
                    throw new InvalidOperationException(string.Format("FileType: {0} is not supported.", file.Type));
            }
        }

        /// <summary>
        /// Build a file info from a local path string. This assumes the local path
        /// resides under the currently executing codes directory.
        /// </summary>
        /// <param name="localPath">The local files path.</param>
        /// <returns>The fully resolved file info.</returns>
        public static FileInfo FromLocalPath(string localPath) {
            string path = Path.Combine(Environment.CurrentDirectory, localPath);
            return new FileInfo(path);
        }

        /// <summary>
        /// Build a file info from a local directory and file name. This assumes the local
        /// path resides under the currently executing codes directory.
        /// </summary>
        /// <param name="localDirectory">The local folder.</param>
        /// <param name="fileName">The file name and extension.</param>
        /// <returns>The fully resolved file info.</returns>
        public static FileInfo FromLocalPath(string localDirectory, string fileName) {
            string path = Path.Combine(Environment.CurrentDirectory, localDirectory, fileName);
            return new FileInfo(path);
        }
        #endregion
    }
}
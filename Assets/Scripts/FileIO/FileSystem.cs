using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoMansBlocks.FileIO {
    /// <summary>
    /// Wrapper for handling loading / saving files to and 
    /// fro the disk.
    /// </summary>
    public static class FileSystem {
        #region Constants
        /// <summary>
        /// How many bytes to read / write from file at a time.
        /// This can be overrided if desired.
        /// </summary>
        private const int BufferSize = 4096;
        #endregion

        #region Properties
        /// <summary>
        /// The parent directory where the code is executing.
        /// </summary>
        public static DirectoryInfo CurrentDirectory { get { return new DirectoryInfo(Environment.CurrentDirectory); } }
        #endregion

        #region Publics
        /// <summary>
        /// Load a file from disk. If the file is not found, a FileNotFoundException
        /// will be thrown.
        /// </summary>
        /// <typeparam name="T">The type of file to load.</typeparam>
        /// <param name="path">The file's full path.</param>
        /// <param name="resolvePath">If the path passed in was a relative path and
        /// needs to be resolved.</param>
        /// <returns>The loaded file.</returns>
        /// <exception cref="FileNotFoundException">When the file isn't found.</exception>
        public static async Task<T> LoadAsync<T>(string path, bool resolvePath = false) where T : IFile {
            FileInfo fileInfo = resolvePath ? ResolveFilePath(path) : new FileInfo(path);
            return await LoadAsync<T>(fileInfo);
        }

        /// <summary>
        /// Load a file from disk. If the file is not found, a FileNotFoundException
        /// will be thrown.
        /// </summary>
        /// <typeparam name="T">The type of file to load.</typeparam>
        /// <param name="info">The info about the file.</param>
        /// <returns>The loaded file.</returns>
        /// <exception cref="FileNotFoundException">When the file isn't found.</exception>
        public static async Task<T> LoadAsync<T>(FileInfo info) where T : IFile {
            byte[] rawContent = await LoadFromFileAsync(info);

            T file = (T)Activator.CreateInstance(typeof(T), info, rawContent);
            return file;
        }

        /// <summary>
        /// Save a file to disk.
        /// </summary>
        /// <typeparam name="T">The type of file to save.</typeparam>
        /// <param name="file">The file to save.</param>
        public static async Task SaveAsync<T>(T file) where T : IFile {
            byte[] rawContent = file.Serialize();
            await SaveToFileAsync(file.Info, rawContent);
        }

        /// <summary>
        /// Build a file info from a local path string. This assumes the local path
        /// resides under the currently executing codes directory.
        /// </summary>
        /// <param name="localPath">The local files path.</param>
        /// <returns>The fully resolved file info.</returns>
        public static FileInfo ResolveFilePath(string localPath) {
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
        public static FileInfo ResolveFilePath(string localDirectory, string fileName) {
            string path = Path.Combine(Environment.CurrentDirectory, localDirectory, fileName);
            return new FileInfo(path);
        }

        /// <summary>
        /// Build a directory info from a local path string. This assumes the local
        /// path resides under the currently executing codes directory.
        /// </summary>
        /// <param name="localPath">The local path.</param>
        /// <returns>The full resolved directory info.</returns>
        public static DirectoryInfo ResolveDirectoryPath(string localPath) {
            string path = Path.Combine(Environment.CurrentDirectory, localPath);
            return new DirectoryInfo(path);
        }

        /// <summary>
        /// Delete the oldest files in the directory if there is more than the 
        /// allowed capacity.
        /// </summary>
        /// <param name="directory">The directory to delete from.</param>
        /// <param name="capacity">The max amount of files allowed in the directory.</param>
        public static void ShrinkDirectory(DirectoryInfo directory, int capacity) {
            FileInfo[] files = directory?.GetFiles();

            //Only do anything when the directory has too many files.
            if ((files?.Length ?? 0) > capacity) {
                files = files.OrderBy(p => p.CreationTime).ToArray();

                int trimCount = files.Length - capacity;
                for (int i = 0; i < trimCount; i++) {
                    files[i].Delete();
                }
            }
        }

        /// <summary>
        /// Checks if an existing file is currently locked and
        /// being used by another process.
        /// </summary>
        /// <param name="fileInfo">The file to check.</param>
        /// <returns>True if the file is locked.</returns>
        public static bool IsFileLocked(FileInfo fileInfo) {
            FileStream stream = null;

            try {
                stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException) {
                return true;
            }
            finally {
                if (stream != null) {
                    stream.Close();
                }
            }

            return false;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Either create or modify an existing file by writing all of its
        /// contents in the form of bytes.
        /// </summary>
        /// <param name="fileInfo">The path of the file.</param>
        /// <param name="fileContents">The content to populate the file with.</param>
        private async static Task SaveToFileAsync(FileInfo fileInfo, byte[] fileContents) {
            if (!fileInfo.Exists) {
                fileInfo.Create().Dispose();
            }

            using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Truncate, FileAccess.Write, FileShare.None, BufferSize, true)) {
                int writeCount = fileContents.Length / BufferSize;

                if(fileContents.Length % BufferSize != 0) {
                    writeCount++;
                }

                for (int i = 0; i < writeCount; i++) {
                    int offset = i * BufferSize;
                    int writeSize = Math.Min(BufferSize, fileContents.Length - i);
                    await fileStream.WriteAsync(fileContents, i * BufferSize, writeSize);
                }
            }
        }

        /// <summary>
        /// Read all of the contents of a file and return it back
        /// as a byte array.
        /// </summary>
        /// <param name="fileInfo">The path of the file to read from.</param>
        /// <param name="timeOut">The maximum number of seconds to wait before timing out.</param>
        /// <returns>The file's contents.</returns>
        private static async Task<byte[]> LoadFromFileAsync(FileInfo fileInfo, float timeOut = 0.5f) {
            float timeWaited = 0.0f;
            while (IsFileLocked(fileInfo)) {
                Thread.Sleep(10);

                if (timeWaited > timeOut) {
                    throw new TimeoutException(string.Format("Load of file {0} time out due to excessive wait time.", fileInfo.ToString()));
                }
            }

            //return await Task.Run(() => {
                //.ReadASync isn't working. This is a temp fix.
                byte[] result;
                using (FileStream stream = fileInfo.OpenRead()) {
                    result = new byte[stream.Length];
                    stream.Read(result, 0, (int)stream.Length);
                }

                return result;
            //});
        }
        #endregion
    }
}

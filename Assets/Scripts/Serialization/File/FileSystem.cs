﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Serialization {
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
        public const int BufferSize = 4096;
        #endregion

        #region Publics
        /// <summary>
        /// Load a file from disk. If the file is not found, a FileNotFoundException
        /// will be thrown.
        /// </summary>
        /// <typeparam name="T">The type of file to load.</typeparam>
        /// <param name="path">The file's full path.</param>
        /// <returns>The loaded file.</returns>
        /// <exception cref="FileNotFoundException">When the file isn't found.</exception>
        public static async Task<T> LoadAsync<T>(string path) where T : IFile {
            return await LoadAsync<T>(new FileInfo(path));
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
        #endregion

        #region Helpers
        /// <summary>
        /// Either create or modify an existing file by writing all of its
        /// contents in the form of bytes.
        /// </summary>
        /// <param name="fileInfo">The path of the file.</param>
        /// <param name="fileContents">The content to populate the file with.</param>
        private async static Task SaveToFileAsync(FileInfo fileInfo, byte[] fileContents) {
            using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, BufferSize, true)) {
                byte[][] fileChunks = fileContents.Split(BufferSize);

                for (int i = 0; i < fileChunks.Length; i++) {
                    await fileStream.WriteAsync(fileChunks[i], 0, fileChunks[i].Length);
                }
            }
        }

        /// <summary>
        /// Read all of the contents of a file and return it back
        /// as a byte array.
        /// </summary>
        /// <param name="fileInfo">The path of the file to read from.</param>
        /// <returns>The file's contents.</returns>
        private static async Task<byte[]> LoadFromFileAsync(FileInfo fileInfo) {
            using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true)) {
                List<byte> content = new List<byte>();
                byte[] byteBuffer = new byte[BufferSize];
                int readCount;

                while ((readCount = await fileStream.ReadAsync(byteBuffer, 0, byteBuffer.Length)) != 0) {
                    content.AddRange(byteBuffer.Take(readCount));
                }

                return content.ToArray();
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// An interface for something that can handle loading, and saving a
    /// specific file type.
    /// </summary>
    public abstract class FileHandler<T> where T: class, IFile {
        #region Properties
        /// <summary>
        /// The type of file this handler supports. FileHandlers
        /// by default only support 1 file type.
        /// </summary>
        public abstract FileType FileType { get; }

        /// <summary>
        /// How many bytes to read / write from file at a time.
        /// This can be overrided in derived classes if desired.
        /// </summary>
        public virtual int BufferSize => 4096;
        #endregion

        #region Publics
        /// <summary>
        /// Load a file from disk using the information passed in. This will
        /// validate that the file handler can even support the file passed in.
        /// </summary>
        /// <param name="fileInfo">The path of the file to load.</param>
        /// <returns>The file (if found).</returns>
        /// <exception cref="ArgumentNullException">If no fileInfo is passed in.</exception>
        /// <exception cref="InvalidOperationException">If the handler does not support the request file type.</exception>
        /// <exception cref="FileNotFoundException">If the file doesn't actually exist.</exception>
        public async Task<T> LoadFileAsync(FileInfo fileInfo) {
            //Was enough info passed?
            if (fileInfo == null) {
                throw new ArgumentNullException("File information was null.");
            }

            //Can we support it?
            if (fileInfo.GetFileType() != FileType) {
                throw new InvalidOperationException(string.Format("File extension {0} is not supported by this handler.", fileInfo.Extension));
            }

            //Does it even exist?
            if (!File.Exists(fileInfo.FullName)) {
                throw new FileNotFoundException(string.Format("File at: {0} does not exist!", fileInfo.FullName));
            }

            return await LoadAsync(fileInfo);
        }

        /// <summary>
        /// Save a file to disk using the info associated with it. This will
        /// validate that the file handler can even support the file first.
        /// </summary>
        /// <param name="file">The file to save to disk.</param>
        /// <exception cref="ArgumentNullException">If no file was passed in.</exception>
        /// <exception cref="ArgumentException">If the file information is bad (IE no path)</exception>
        /// <exception cref="InvalidOperationException">If the file is not supported by this handler</exception>
        public async Task SaveFileAsync(T file) {
            if (file == null) {
                throw new ArgumentNullException("File passed in was null");
            }

            if (file.Info == null || file.Info.FullName == null) {
                throw new ArgumentException("Insufficent data passed with the file info. Cannot save to disk.");
            }

            if (file.Info.GetFileType() != FileType) {
                throw new InvalidOperationException(string.Format("File extension {0} is not supported by this handler.", file.Info.Extension));
            }

            await SaveAsync(file);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Load a file from disk. This is implemented by the derived class to
        /// provide the actual functionality of the handler.
        /// </summary>
        /// <param name="fileInfo">Where the file resides.</param>
        /// <returns>The loaded file.</returns>
        protected abstract Task<T> LoadAsync(FileInfo fileInfo);

        /// <summary>
        /// Save a file to disk. This is implemented by the derived class to
        /// provide the actual functionality.
        /// </summary>
        /// <param name="filePath">Where to save the file to.</param>
        /// <param name="file">The file to save.</param>
        protected abstract Task SaveAsync(T file);

        /// <summary>
        /// Either create or modify an existing file by writing all of its
        /// contents in the form of bytes.
        /// </summary>
        /// <param name="fileInfo">The path of the file.</param>
        /// <param name="fileContents">The content to populate the file with.</param>
        protected async Task WriteToFileAsync(FileInfo fileInfo, byte[] fileContents) {
            using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, BufferSize, true)) {
                byte[][] fileChunks = fileContents.Split(BufferSize);

                for(int i = 0; i < fileChunks.Length; i++) {
                    await fileStream.WriteAsync(fileChunks[i], i * BufferSize, fileChunks[i].Length);
                }
            }
        }

        /// <summary>
        /// Read all of the contents of a file and return it back
        /// as a byte array.
        /// </summary>
        /// <param name="fileInfo">The path of the file to read from.</param>
        /// <returns>The file's contents.</returns>
        protected async Task<byte[]> ReadFromFileAsync(FileInfo fileInfo) {
            using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true)) {
                List<byte> content = new List<byte>();
                byte[] byteBuffer = new byte[BufferSize];
                int readCount;

                while ((readCount = await fileStream.ReadAsync(byteBuffer, 0, byteBuffer.Length)) != 0) {
                    content.AddRange(byteBuffer);
                }

                return content.ToArray();
            }
        }
        #endregion
    }
}
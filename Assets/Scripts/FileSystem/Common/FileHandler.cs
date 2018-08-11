using System;
using System.IO;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// An interface for something that can handle loading, and saving a
    /// specific file type.
    /// </summary>
    public abstract class FileHandler {
        #region Properties
        /// <summary>
        /// The type of file this handler supports.
        /// </summary>
        public abstract FileType FileType { get; }

        /// <summary>
        /// The extension of files that this handler
        /// supports. Do not include the dot.
        /// </summary>
        public abstract string FileExtension { get; }
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
        public async Task<IFile> LoadFileAsync(FileInfo fileInfo) {
            //Was enough info passed?
            if(fileInfo == null) {
                throw new ArgumentNullException("File information was null.");
            }

            //Can we support it?
            if (!fileInfo.Extension.Equals(FileExtension)) {
                throw new InvalidOperationException(string.Format("File extension {0} is not supported by this handler.", fileInfo.Extension));
            }

            //Does it even exist?
            if (!File.Exists(fileInfo.Path)) {
                throw new FileNotFoundException(string.Format("File at: {0} does not exist!", fileInfo.Path));
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
        public async Task SaveFileAsync(IFile file) {
            if(file == null) {
                throw new ArgumentNullException("File passed in was null");
            }

            if(file.Info == null || file.Info.Path == null || file.Info.Extension == null) {
                throw new ArgumentException("Insufficent data passed with the file info. Cannot save to disk.");
            }

            if (!file.Info.Extension.Equals(FileExtension)) {
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
        protected abstract Task<IFile> LoadAsync(FileInfo fileInfo);

        /// <summary>
        /// Save a file to disk. This is implemented by the derived class to
        /// provide the actual functionality.
        /// </summary>
        /// <param name="filePath">Where to save the file to.</param>
        /// <param name="file">The file to save.</param>
        protected abstract Task SaveAsync(IFile file);
        #endregion
    }
}
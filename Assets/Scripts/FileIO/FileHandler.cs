using NoMansBlocks.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NoMansBlocks.FileIO {
    /// <summary>
    /// Base class for custom file handlers to derive from. This provides
    /// the foundations for saving / loading to file.
    /// </summary>
    public class FileHandler<T> where T : IFile  {
        #region Properties
        /// <summary>
        /// The directory that the file handler saves files under.
        /// This is relative to the code executing directory.
        /// </summary>
        public virtual string Directory { get; }

        /// <summary>
        /// The maximum number of files allowed in the directory.
        /// Leave this as 0, if no limit. This only works if a 
        /// file directory has been specified.
        /// </summary>
        public virtual int Capacity { get; }
        #endregion

        #region Publics
        /// <summary>
        /// Create a new empty file of the FileHandlers type.
        /// This DOES NOT save the file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The newly created file.</returns>
        public T Create(string fileName) {
            FileInfo fileInfo = ResolveFilePath(fileName);
            return (T) Activator.CreateInstance(typeof(T), fileInfo);
        }

        /// <summary>
        /// Create a new file of the FileHandlers type.
        /// This DOES NOT save the file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="content">The content of the file.</param>
        /// <returns>The newly created file.</returns>
        public T Create(string fileName, object content) {
            FileInfo fileInfo = ResolveFilePath(fileName);
            return (T)Activator.CreateInstance(typeof(T), fileInfo, content);
        }

        /// <summary>
        /// Save a file to the directory of the
        /// file handler.
        /// </summary>
        /// <param name="file">The file to save.</param>
        /// <returns>True if the operation completed successfully.</returns>
        public async Task SaveAsync(T file) {
            //Validate the directory.
            DirectoryInfo fileDirectory = null;
            if (Directory != null) {
                fileDirectory = FileSystem.ResolveDirectoryPath(Directory);

                //Create the directory if it doesn't exist.
                if (!fileDirectory.Exists) {
                    fileDirectory.Create();
                }
            }

            //Now save the file.
            await FileSystem.SaveAsync(file);
       
            //Do we need to shrink it at all?
            if(fileDirectory != null && Capacity > 0) {
                if (fileDirectory.FileCount() > Capacity) {
                    FileSystem.ShrinkDirectory(fileDirectory, Capacity);
                }
            }
        }

        /// <summary>
        /// Load a file from the local directory of the file handler.
        /// </summary>
        /// <param name="fileName">The name of the file to load.</param>
        /// <returns>The loaded file. (If it exists)</returns>
        public async Task<T> LoadAsync(string fileName) {
            FileInfo fileInfo = ResolveFilePath(fileName);
            return await FileSystem.LoadAsync<T>(fileInfo);
        }

        /// <summary>
        /// Checks if the file handler has a file with the specified
        /// name or not.
        /// </summary>
        /// <param name="fileName">The filename to look for.</param>
        /// <returns>True if the file exists.</returns>
        public bool Exists(string fileName) {
            FileInfo fileInfo = ResolveFilePath(fileName);
            return File.Exists(fileName);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Resolve the filepath with the file handler using the directory
        /// if one has been specified.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected FileInfo ResolveFilePath(string fileName)
        {
            if (Directory != null) {
                return FileSystem.ResolveFilePath(Directory, fileName);
            }
            else {
                return FileSystem.ResolveFilePath(fileName);
            }
        }
        #endregion
    }
}

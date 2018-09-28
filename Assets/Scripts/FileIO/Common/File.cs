using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.FileIO {
    /// <summary>
    /// Base class for every file to derive from. This allows us to
    /// access the content of the file regardless of how it is saved.
    /// </summary>
    /// <typeparam name="T">The object that the file holds.</typeparam>
    public abstract class File<T> : IFile where T : class {
        #region Properties
        /// <summary>
        /// Indicator for what kind of file it is. 
        /// </summary>
        public abstract FileType Type { get; }

        /// <summary>
        /// The info about the file.
        /// </summary>
        public FileInfo Info { get; protected set; }

        /// <summary>
        /// The content stored in the file.
        /// </summary>
        public T Content { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty file object.
        /// </summary>
        /// <param name="info">The path of the file to use.</param>
        protected File(FileInfo info) {
            Info = info;
            Content = null;
        }

        /// <summary>
        /// Create a new file object that holds the content
        /// passed in.
        /// </summary>
        /// <param name="info">The info such as 
        /// directory about the file.</param>
        /// <param name="content">The content to store in
        /// the file.</param>
        protected File(FileInfo info, T content) {
            Info = info;
            Content = content;
        }

        /// <summary>
        /// Deserialize a file from it's byte array.
        /// </summary>
        /// <param name="info">The info such as 
        /// directory about the file.</param>
        /// <param name="content">The raw bytes of the file.</param>
        protected File(FileInfo info, byte[] content) {
            Info = info;
            Content = Deserialize(content);
        }
        #endregion

        #region Publics
        /// <summary>
        /// Serialize the content of the file into
        /// a byte array that can be saved to disk.
        /// </summary>
        /// <returns>The serialized content as a byte array.</returns>
        public abstract byte[] Serialize();
        #endregion

        #region Helpers
        /// <summary>
        /// Deserialize the content of the file and rebuild the
        /// actual object stored in it.
        /// </summary>
        /// <param name="content">The raw bytes of the file.</param>
        /// <returns>The rebuilt content.</returns>
        protected abstract T Deserialize(byte[] content);
        #endregion
    }
}

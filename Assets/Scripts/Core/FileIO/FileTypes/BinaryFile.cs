using NoMansBlocks.Core.Serialization.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.FileIO {
    /// <summary>
    /// A binary file is one that uses raw bytes to store
    /// it's content.
    /// </summary>
    public class BinaryFile<T> : File<T> where T : class, IBinarySerializable {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it is.
        /// </summary>
        public override FileType Type => FileType.Binary;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty binary file with the info passed in.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        protected BinaryFile(FileInfo info) : base(info) {
        }

        /// <summary>
        /// Create a new binary file with the information passed
        /// in.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">The content to store in the file.</param>
        public BinaryFile(FileInfo info, T content) : base(info, content){
        }

        /// <summary>
        /// Deserialize a binary file.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">The raw content of the file.</param>
        public BinaryFile(FileInfo info, byte[] content) : base(info, content) {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Serialize the content of the file into a byte
        /// array that can be saved to disk.
        /// </summary>
        /// <returns>The content of the file serialized.</returns>
        public override byte[] Serialize() {
            return Content.Serialize();
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Rebuild the content of the file using 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>The rebuilt content of the file.</returns>
        protected override T Deserialize(byte[] content) {
            return (T)Activator.CreateInstance(typeof(T), content);
        }
        #endregion
    }
}

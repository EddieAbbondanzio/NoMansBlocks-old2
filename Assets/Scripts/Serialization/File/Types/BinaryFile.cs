using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Serialization {
    /// <summary>
    /// A binary file is one that uses raw bytes to store
    /// it's content.
    /// </summary>
    public class BinaryFile<T> : File<T> where T : IBinarySerializable {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it is.
        /// </summary>
        public override FileType Type => FileType.Binary;

        /// <summary>
        /// What kind of compression to use for
        /// storing the file on disk.
        /// </summary>
        public CompressionType Compression { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new binary file with the information passed
        /// in.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">The content to store in the file.</param>
        public BinaryFile(FileInfo info, T content) : base(info, content){
            Compression = CompressionType.None;
        }

        /// <summary>
        /// Deserialize a binary file.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">The raw content of the file.</param>
        public BinaryFile(FileInfo info, byte[] content) : base(info, content) {
            Compression = CompressionType.None;
        }

        /// <summary>
        /// Create a new binary file with a custom compression type.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">The content to store in the file.</param>
        /// <param name="compression">The compression method to use on the file.</param>
        public BinaryFile(FileInfo info, T content, CompressionType compression) : base(info, content) {
            Compression = compression;
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
            throw new NotImplementedException();
        }
        #endregion
    }
}

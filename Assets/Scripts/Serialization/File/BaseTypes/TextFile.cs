using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Serialization {
    /// <summary>
    /// A text file is one that can only hold, well...
    /// text in it.
    /// </summary>
    public sealed class TextFile : File<string> {
        #region Properties
        /// <summary>
        /// Indicator for what kind of file it is.
        /// </summary>
        public override FileType Type => FileType.Text;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new text file with the info passed in.
        /// The default encoding is UTF8.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">The text of the file.</param>
        public TextFile(FileInfo info, string content) : base(info, content) {
        }

        /// <summary>
        /// Deserialize a text file from disk using UTF8 encoding.
        /// </summary>
        /// <param name="info">The info about the file.</param>
        /// <param name="content">The raw content of the file.</param>
        public TextFile(FileInfo info, byte[] content) : base(info, content) {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Serialize the content of the file into a byte
        /// array that can be saved to disk.
        /// </summary>
        /// <returns>The content of the file serialized.</returns>
        public override byte[] Serialize() {
            return Encoding.UTF8.GetBytes(Content);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Rebuild the content of the file using 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>The rebuilt content of the file.</returns>
        protected override string Deserialize(byte[] content) {
            return Encoding.UTF8.GetString(content);
        }
        #endregion
    }
}

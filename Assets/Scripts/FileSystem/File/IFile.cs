using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// An interface to represent any kind of file that
    /// may need to be saved or loaded.
    /// </summary>
    public interface IFile {
        #region Properties
        /// <summary>
        /// Indicator for what kind of file it is.
        /// </summary>
        FileType Type { get; }

        /// <summary>
        /// The path information of the file.
        /// </summary>
        FileInfo Info { get; }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoMansBlocks.FileIO {
    /// <summary>
    /// Extensions for the DirectoryInfo class.
    /// </summary>
    public static class DirectoryInfoExtensions {
        #region Publics
        /// <summary>
        /// The number of children that the directory contains. This
        /// only counts files.
        /// </summary>
        /// <param name="directory">The directory to find children for.</param>
        /// <returns>The number of files it holds.</returns>
        public static int FileCount(this DirectoryInfo directory) {
            return directory.GetFiles().Length;
        }
        #endregion
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMansBlocks.Core.Serialization;
using System.IO;
using NoMansBlocks.Core.FileIO;

namespace NoMansBlocks.Tests.Serialization {
    /// <summary>
    /// Tests pertaining to the TextFile class and it's handler.
    /// </summary>
    [TestClass]
    [TestCategory("FileIO")]
    public class TextFileIOTests {
        /// <summary>
        /// Checks if the FileInfo object associates .txt with FileType.Text;
        /// </summary>
        [TestMethod]
        public void IsFileTypeText() {
            FileInfo fileInfo = new FileInfo(@"\test\file.txt");
            Assert.AreEqual(FileType.Text, fileInfo.GetFileType());
        }
    }
}

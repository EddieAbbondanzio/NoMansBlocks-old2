using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMansBlocks.Serialization;
using System.IO;

namespace NoMansBlocks.Tests.Serialization {
    [TestClass]
    [TestCategory("FileIO")]
    public class BinaryFileIOTests {
        /// <summary>
        /// Check if the .bin file extension is related
        /// to FileType.Binary or not.
        /// </summary>
        [TestMethod]
        public void IsFileTypeBinary() {
            FileInfo fileInfo = new FileInfo(@"\directory\test.bin");
            Assert.AreEqual(FileType.Binary, fileInfo.GetFileType());
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMansBlocks.Core.Serialization;
using System.IO;
using NoMansBlocks.Core.FileIO;

namespace NoMansBlocks.Tests.Serialization {
    /// <summary>
    /// Unit Tests related to .json files and their FileHandler
    /// </summary>
    [TestClass]
    public class JsonFileIOTests {
        /// <summary>
        /// Check if the .json file extension is related
        /// to FileType.Json or not.
        /// </summary>
        [TestMethod]
        public void IsFileTypeJson() {
            FileInfo fileInfo = new FileInfo(@"\directory\test.json");
            Assert.AreEqual(FileType.Json, fileInfo.GetFileType());
        }
    }
}

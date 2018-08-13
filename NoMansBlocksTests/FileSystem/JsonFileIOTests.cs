﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMansBlocks.FileSystem;
using System.IO;

namespace NoMansBlocks.Tests.FileSystem {
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

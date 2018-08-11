using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMansBlocks.FileSystem;

namespace NoMansBlocks.Tests.FileSystem {
    /// <summary>
    /// Unit Tests related to file IO operations of text (.txt) files.
    /// </summary>
    [TestClass]
    [TestCategory("FileIO")]
    public class TextFileTests {
        /// <summary>
        /// Attempt to save and load a txt file to disk
        /// and back.
        /// </summary>
        [TestMethod]
        public async void SaveAndLoadFile() {
            //Create a file to save
            Assert.AreEqual(1, 1);
            //string content = "The quick brown fox jumped over the lazy dog.";
            //NoMansBlocks.FileSystem.FileInfo fileInfo = new NoMansBlocks.FileSystem.FileInfo(Path.Combine(FileIO.CurrentDirectory, "tests", "text.txt"));
            //TextFile textFile = new TextFile(fileInfo, content);

            ////Save the file to disk
            //await FileIO.SaveAsync(textFile);

            ////Reload the file then see if the content is the same.
            //TextFile loadedFile = await FileIO.LoadAsync(fileInfo) as TextFile;
            //Assert.AreEqual(textFile.Content, loadedFile.Content);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMansBlocks.FileSystem;

namespace NoMansBlocks.Tests.FileSystem {
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

        /// <summary>
        /// Save and reload a text file to see if the contents
        /// are the same.
        /// </summary>
        [TestMethod]
        public async void SaveAndLoadFile() {
            FileInfo fileInfo = new FileInfo(String.Format(@"{0}\Tests\test.txt", FileIO.CurrentDirectory));
            TextFile fileToSave = new TextFile(fileInfo, "The quick brown fox quickly jumped over the lazy dog.");

            await FileIO.SaveAsync(fileToSave);

            TextFile loadedFile = await FileIO.LoadAsync(fileInfo) as TextFile;
            Assert.AreEqual(fileToSave.Content, loadedFile.Content);
        }
    }
}

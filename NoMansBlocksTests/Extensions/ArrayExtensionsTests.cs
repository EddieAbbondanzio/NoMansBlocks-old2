using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMansBlocks.Core.FileIO;
using NoMansBlocks.Core.Serialization;

namespace NoMansBlocks.Tests.Extensions {
    /// <summary>
    /// Unit Tests for the extensions of the array class.
    /// </summary>
    [TestClass]
    public class ArrayExtensionsTests {
        /// <summary>
        /// Test getting a sub array from an array and seeing if the sub array
        /// matches what it's suppose to be.
        /// </summary>
        [TestMethod]
        public void SubArrayTest() {
            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            int[] sub = array.SubArray(2, 4);

            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5 }, sub);
        }

        /// <summary>
        /// Tests splitting an array that divides up nicely with
        /// the split size.
        /// </summary>
        [TestMethod]
        public void CleanSplitTest() {
            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            int[][] splits = array.Split(2);

            CollectionAssert.AreEqual(new int[] { 0, 1 }, splits[0]);
            CollectionAssert.AreEqual(new int[] { 2, 3 }, splits[1]);
            CollectionAssert.AreEqual(new int[] { 4, 5 }, splits[2]);
            CollectionAssert.AreEqual(new int[] { 6, 7 }, splits[3]);
        }

        /// <summary>
        /// Tests splitting an array that doesn't divide evenly
        /// by it's chunk split size.
        /// </summary>
        [TestMethod]
        public void SmallerLastChunkSplitTest() {
            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int[][] splits = array.Split(2);

            CollectionAssert.AreEqual(new int[] { 0, 1 }, splits[0]);
            CollectionAssert.AreEqual(new int[] { 2, 3 }, splits[1]);
            CollectionAssert.AreEqual(new int[] { 4, 5 }, splits[2]);
            CollectionAssert.AreEqual(new int[] { 6, 7 }, splits[3]);
            CollectionAssert.AreEqual(new int[] { 8 }, splits[4]);
        }
    }
}

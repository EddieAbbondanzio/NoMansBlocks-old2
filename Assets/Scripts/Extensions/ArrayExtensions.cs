using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks {
    /// <summary>
    /// Array based extensions that provide additional functionality to
    /// the array class.
    /// </summary>
    public static class ArrayExtensions {
        /// <summary>
        /// Extract a sub array from an already existing array.
        /// </summary>
        /// <typeparam name="T">The type of array.</typeparam>
        /// <param name="data">The array to copy from.</param>
        /// <param name="index">The first position in the array to copy.</param>
        /// <param name="length">How large of a copy to perform.</param>
        /// <returns>The extract subarray.</returns>
        public static T[] SubArray<T>(this T[] data, int index, int length) {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Split an array into several smaller ones that are all of
        /// the same size. The last section of the array may be smaller
        /// than others if the array doesn't divide nicely.
        /// </summary>
        /// <typeparam name="T">The type of array.</typeparam>
        /// <param name="data">The array to split up</param>
        /// <param name="chunkSize">How large each chunk should be.</param>
        /// <returns>The split up array.</returns>
        public static T[][] Split<T>(this T[] data, int chunkSize) {
            int splitCount = data.Length / chunkSize;

            if(data.Length % chunkSize != 0) {
                splitCount++;
            }

            T[][] chunks = new T[splitCount][];

            for(int i = 0; i < splitCount; i++) {
                int currSize = i == (splitCount - 1) ? Math.Min(data.Length - (i * chunkSize), chunkSize) : chunkSize;
                chunks[i] = data.SubArray(i * chunkSize, currSize);
            }

            return chunks;
        }
    }
}

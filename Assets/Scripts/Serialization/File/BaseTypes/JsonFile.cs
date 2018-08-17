﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Serialization {
    /// <summary>
    /// File that uses JSON as it's storage method.
    /// </summary>
    /// <typeparam name="T">The type of object the
    /// file stores.</typeparam>
    public class JsonFile<T> : File<T> {
        #region Properties
        /// <summary>
        /// The type of file it is.
        /// </summary>
        public override FileType Type => FileType.Json;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new JSON file with the content passed in.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">What to store in the file.</param>
        public JsonFile(FileInfo info, T content) : base(info, content){
        }

        /// <summary>
        /// Deserialize a JSON file from text using UTf8 as the encoding.
        /// </summary>
        /// <param name="info">The info of the file.</param>
        /// <param name="content">The raw content of the file.</param>
        public JsonFile(FileInfo info, byte[] content) : base(info, content) {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Serialize the content of the file into a byte
        /// array that can be saved to disk.
        /// </summary>
        /// <returns>The content of the file serialized.</returns>
        public override byte[] Serialize() {
            string jsonString = JsonConvert.SerializeObject(Content);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Rebuild the content of the file using 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>The rebuilt content of the file.</returns>
        protected override T Deserialize(byte[] content) {
            string jsonString = Encoding.UTF8.GetString(content);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        #endregion
    }
}
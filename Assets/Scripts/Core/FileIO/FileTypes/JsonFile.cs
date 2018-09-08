using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.FileIO {
    /// <summary>
    /// File that uses JSON as it's storage method.
    /// </summary>
    /// <typeparam name="T">The type of object the
    /// file stores.</typeparam>
    public class JsonFile<T> : File<T> where T : class {
        #region Properties
        /// <summary>
        /// The type of file it is.
        /// </summary>
        public override FileType Type => FileType.Json;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty JSON file.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        public JsonFile(FileInfo info) : base(info) {
        }

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
            //See if we can find a JsonConverter attribute on the derived class
            JsonConverterAttribute converterAttribute = GetType().GetCustomAttribute<JsonConverterAttribute>();

            string jsonString;
            if(converterAttribute != null) {
                JsonConverter jsonConverter = Activator.CreateInstance(converterAttribute.ConverterType) as JsonConverter;
                jsonString = JsonConvert.SerializeObject(Content, jsonConverter);
            }
            else {
                jsonString = JsonConvert.SerializeObject(Content);
            }

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

            JsonConverterAttribute converterAttribute = GetType().GetCustomAttribute<JsonConverterAttribute>();
            if (converterAttribute != null) {
                JsonConverter jsonConverter = Activator.CreateInstance(converterAttribute.ConverterType) as JsonConverter;
                return JsonConvert.DeserializeObject<T>(jsonString, jsonConverter);
            }
            else {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
        }
        #endregion
    }
}

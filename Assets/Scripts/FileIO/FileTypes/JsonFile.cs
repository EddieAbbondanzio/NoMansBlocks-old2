using Newtonsoft.Json;
using NoMansBlocks.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.FileIO {
    /// <summary>
    /// File that uses JSON as it's storage method.
    /// </summary>
    /// <typeparam name="T">The type of object the
    /// file stores.</typeparam>
    public abstract class JsonFile<T> : File<T> where T : class {
        #region Properties
        /// <summary>
        /// The type of file it is.
        /// </summary>
        public override FileType Type => FileType.Json;

        /// <summary>
        /// The type of formatting to use to write to the file.
        /// </summary>
        public virtual Formatting Formatting => Formatting.None;
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
            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(stringBuilder)) {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter)) {
                    jsonWriter.Formatting = Formatting;

                    SerializeContent(jsonWriter, new JsonSerializer());
                }
            }

            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
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

            using (StringReader stringReader = new StringReader(jsonString)) {
                using(JsonTextReader jsonReader = new JsonTextReader(stringReader)) {
                    return DeserializeContent(jsonReader, new JsonSerializer());
                }
            }
        }

        /// <summary>
        /// Serialize the content of the file into it's JSON representation.
        /// </summary>
        /// <param name="writer">The writer to use.</param>
        /// <param name="serializer">The helper serializer.</param>
        protected virtual void SerializeContent(JsonWriter writer, JsonSerializer serializer) {
            serializer.Serialize(writer, Content);
        }

        /// <summary>
        /// Deserialize the content of the file back into it's original form.
        /// </summary>
        /// <param name="reader">The reader to read from.</param>
        /// <param name="serializer">The helper serializer.</param>
        protected virtual T DeserializeContent(JsonReader reader, JsonSerializer serializer) {
            return serializer.Deserialize(reader) as T;
        }
        #endregion
    }
}

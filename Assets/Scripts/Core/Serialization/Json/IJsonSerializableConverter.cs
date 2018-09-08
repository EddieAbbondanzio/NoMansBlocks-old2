using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Serialization.Json {
    /// <summary>
    /// Json Converter to handle converting IJsonSerializable objects
    /// to JSON and back.
    /// </summary>
    public class IJsonSerializableConverter : JsonConverter {
        #region Publics
        /// <summary>
        /// If the converter can handle converting the passed in
        /// type. This only returns true for objects that implement
        /// IJsonSerializable.
        /// </summary>
        /// <param name="objectType">The type of object to test.</param>
        /// <returns>True if of type IJsonSerializable</returns>
        public override bool CanConvert(Type objectType) {
            return typeof(IJsonSerializable).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Read in JSON and attempt to rebuild an object from it's
        /// JSON form.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            IJsonSerializable jsonSerializable = Activator.CreateInstance(objectType, reader, serializer) as IJsonSerializable;
            return jsonSerializable;
        }

        /// <summary>
        /// Write an object to JSON. 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            IJsonSerializable jsonSerializable = value as IJsonSerializable;
            jsonSerializable.Serialize(writer, serializer);
        }
        #endregion
    }
}

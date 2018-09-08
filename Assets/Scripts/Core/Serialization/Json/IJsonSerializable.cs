using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Serialization.Json {
    /// <summary>
    /// Interface to indicate that an object can be serialized into
    /// JSON and back. This expects the object to also implement a 
    /// constructor that takes parameters of (JsonReader, JsonSerializer).
    /// </summary>
    [JsonConverter(typeof(IJsonSerializableConverter))]
    public interface IJsonSerializable {
        /// <summary>
        /// Serialize the object into JSON by writing it to the writer.
        /// </summary>
        /// <param name="writer">The write to use to write JSON with.</param>
        /// <param name="serializer">Helper serializer.</param>
        void Serialize(JsonWriter writer, JsonSerializer serializer);
    }
}

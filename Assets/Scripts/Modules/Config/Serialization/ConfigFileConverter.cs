using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Converter for converting ConfigFile contents to a JSON string
    /// and back.
    /// </summary>
    public sealed class ConfigFileConverter : JsonConverter {
        #region Publics
        /// <summary>
        /// Check if the converter can convert the object type 
        /// passed in into json.
        /// </summary>
        /// <param name="objectType">The object type to check.</param>
        /// <returns>True if it is a list of configs.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(List<IConfig>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
        #endregion
    }
}

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

        /// <summary>
        /// Read the config file from it's raw JSON format.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            List<IConfig> configs = new List<IConfig>();

            while (reader.Read()) {
                if(reader.Value != null) {
                    if(reader.TokenType == JsonToken.PropertyName) {

                        ConfigType configType = (ConfigType) Enum.Parse(typeof(ConfigType), reader.Value.ToString());
                        reader.Read();

                        Type type = ConfigUtils.GetType(configType);
                        IConfig config = Activator.CreateInstance(type, reader, serializer) as IConfig;
                   
                        if(config != null) {
                            configs.Add(config);
                        }
                    }
                }
            }

            return configs;
        }

        /// <summary>
        /// Write the list of configs to JSON that can be saved to the file.
        /// </summary>
        /// <param name="writer">The writer to write with.</param>
        /// <param name="value">The list of configs.</param>
        /// <param name="serializer">The helper serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.Formatting = Formatting.Indented;
            List<IConfig> configs = value as List<IConfig>;

            writer.WriteStartObject();

            for(int i = 0; i < configs.Count; i++) {
                writer.WritePropertyName(configs[i].ConfigType.ToString());
                serializer.Serialize(writer, configs[i]);
            }

            writer.WriteEndObject();
        }
        #endregion
    }
}

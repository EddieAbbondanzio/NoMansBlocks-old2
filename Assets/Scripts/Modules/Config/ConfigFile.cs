using Newtonsoft.Json;
using NoMansBlocks.Core.FileIO;
using NoMansBlocks.Core.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// The file that holds all of the configs.
    /// </summary>
    [Serializable]
    public sealed class ConfigFile : JsonFile<List<IConfig>> {
        #region Properties
        /// <summary>
        /// Config files will be read by users so they should
        /// be pretty.
        /// </summary>
        public override Formatting Formatting => Formatting.Indented;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty config file.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        public ConfigFile(FileInfo info) : base(info) {
        }

        /// <summary>
        /// Create a new config file using the configs passed in.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        /// <param name="configs">The configs to store in it.</param>
        public ConfigFile(FileInfo info, List<IConfig> configs) : base (info, configs) {
        }

        /// <summary>
        /// Deserialize a config file from disk.
        /// </summary>
        /// <param name="info">The path of the file.</param>
        /// <param name="content">The raw content of the file.</param>
        public ConfigFile(FileInfo info, byte[] content) : base (info, content) {
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Serialize the content of the file into a JSON string.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="serializer">The helper serializer.</param>
        protected override void SerializeContent(JsonWriter writer, JsonSerializer serializer) {
            writer.WriteStartObject();

            for (int i = 0, contentCount = Content.Count; i < contentCount; i++) {
                writer.WritePropertyName(Content[i].ConfigType.ToString());
                serializer.Serialize(writer, Content[i]);
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the content of the file and rebuild the list of IConfigs.
        /// </summary>
        /// <param name="reader">The reader to pull in from.</param>
        /// <param name="serializer">The helper serializer.</param>
        /// <returns>The rebuilt file content.</returns>
        protected override List<IConfig> DeserializeContent(JsonReader reader, JsonSerializer serializer) {
            List<IConfig> configs = new List<IConfig>();

            while (reader.Read()) {
                if (reader.Value != null) {
                    if (reader.TokenType == JsonToken.PropertyName) {

                        ConfigType configType = (ConfigType)Enum.Parse(typeof(ConfigType), reader.Value.ToString());
                        reader.Read();

                        Type type = ConfigUtils.GetType(configType);
                        IConfig config = Activator.CreateInstance(type, reader, serializer) as IConfig;

                        if (config != null) {
                            configs.Add(config);
                        }
                    }
                }
            }

            return configs;
        }
        #endregion
    }
}

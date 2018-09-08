using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NoMansBlocks.Core.Engine;

namespace NoMansBlocks.Modules.Config {
    /// <summary>
    /// Settings that pertain to the network module.
    /// </summary>
    public sealed class NetworkConfig : IConfig {
        #region Properties
        /// <summary>
        /// The type of config object it is.
        /// </summary>
        public ConfigType ConfigType => ConfigType.Network;

        /// <summary>
        /// The type of engine this network config supports
        /// </summary>
        public GameEngineType EngineType => GameEngineType.All;

        /// <summary>
        /// The port number to listen on.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The maximum number of connections to allow.
        /// </summary>
        public int ConnectionCapacity { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty NetworkConfig. This is required
        /// by the ConfigModule.
        /// </summary>
        public NetworkConfig() {
        }

        /// <summary>
        /// Create a new instance of the network config.
        /// </summary>
        /// <param name="port">The port to listen on.</param>
        /// <param name="capacity">The maximum number of connections.</param>
        public NetworkConfig(int port, int capacity) {
            Port = port;
            ConnectionCapacity = capacity;
        }

        /// <summary>
        /// Deserialize a Network Config from it's JSON form.
        /// </summary>
        /// <param name="reader">The reader to read JSON from.</param>
        /// <param name="serializer">Helper for deserializing.</param>
        public NetworkConfig(JsonReader reader, JsonSerializer serializer) {
            JObject jObject = JObject.ReadFrom(reader) as JObject;

            Port               = jObject["Port"].Value<int>();
            ConnectionCapacity = jObject["ConnectionCapacity"].Value<int>();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Reset the network configs back their default
        /// settings based on the engine type.
        /// </summary>
        /// <param name="engineType">The type of engine running.</param>
        public void ResetToDefault(GameEngineType engineType) {
            switch (engineType) {
                case GameEngineType.Client:
                    Port = 0;
                    ConnectionCapacity = 1;
                    break;
                case GameEngineType.Server:
                    Port = 9550;
                    ConnectionCapacity = 32;
                    break;
            }
        }

        /// <summary>
        /// Validate the network config to ensure nothing
        /// was messed with.
        /// </summary>
        /// <param name="engineType">The engine type to check parameters for.</param>
        /// <returns>True if everything is good.</returns>
        public bool Validate(GameEngineType engineType) {
            switch(engineType) {
                case GameEngineType.Client:
                    return Port == 0 && ConnectionCapacity == 1;
                case GameEngineType.Server:
                    return Port > 0 && ConnectionCapacity >= 4 && ConnectionCapacity <= 32;
            }

            return false;
        }

        /// <summary>
        /// Serialize the config object to JSON.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="serializer">The serializer to serialize with</param>
        public void Serialize(JsonWriter writer, JsonSerializer serializer) {
            writer.WriteStartObject();

            writer.WritePropertyName("Port");
            serializer.Serialize(writer, Port);

            writer.WritePropertyName("ConnectionCapacity");
            serializer.Serialize(writer, ConnectionCapacity);

            writer.WriteEndObject();
        }
        #endregion
    }
}

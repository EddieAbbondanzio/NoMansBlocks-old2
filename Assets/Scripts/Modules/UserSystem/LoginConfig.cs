using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UserSystem {
    /// <summary>
    /// Settings that pertain to the user module.
    /// </summary>
    public sealed class LoginConfig : IConfig {
        #region Constants
        /// <summary>
        /// Property name to use in the JSON file for
        /// the Username.
        /// </summary>
        private const string UsernameJsonName = "Username";

        /// <summary>
        /// Property name to use in the JSON file for
        /// the Token.
        /// </summary>
        private const string TokenJsonName = "Token";

        /// <summary>
        /// Property name to use in the JSON file for
        /// the Remember Me.
        /// </summary>
        private const string RememberMeJsonName = "RememberMe";
        #endregion

        #region Properties
        /// <summary>
        /// The type of config object it is.
        /// </summary>
        public ConfigType ConfigType => ConfigType.Login;

        /// <summary>
        /// The type of engine this network config supports
        /// </summary>
        public GameEngineType EngineType => GameEngineType.Client;

        /// <summary>
        /// The username to save.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The login token to use on the next login.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// If the user wants their credentials to be
        /// kept or not.
        /// </summary>
        public bool RememberMe { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the login config that
        /// does not save credentials.
        /// </summary>
        public LoginConfig() {
        }

        /// <summary>
        /// Create a new instance of the login config that 
        /// saves credentials.
        /// </summary>
        /// <param name="username">The username to save.</param>
        /// <param name="loginToken">The (JWT) login token to save.</param>
        public LoginConfig(string username, string loginToken) {
            Username   = username;
            Token      = loginToken;
            RememberMe = true;
        }

        /// <summary>
        /// Deserialize a login config from it's json form.
        /// </summary>
        /// <param name="reader">The reader to read json from.</param>
        /// <param name="serializer">Helper for deserializing.</param>
        public LoginConfig(JsonReader reader, JsonSerializer serializer) {
            JObject jObject = JObject.ReadFrom(reader) as JObject;

            Username   = jObject[UsernameJsonName]?.Value<string>();
            Token      = jObject[TokenJsonName]?.Value<string>();
            RememberMe = jObject[RememberMeJsonName]?.Value<bool>() ?? false;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Reset the login config back to defaults.
        /// </summary>
        /// <param name="engineType">The currently running game engine type.</param>
        public void ResetToDefault(GameEngineType engineType) {
            Username   = null;
            Token      = null;
            RememberMe = false;
        }

        /// <summary>
        /// Nothing to really validate.
        /// </summary>
        /// <param name="engineType">The currently running game engine type.</param>
        /// <returns>True if the config is valid.</returns>
        public bool Validate(GameEngineType gameEngineType) {
            return true;
        }

        /// <summary>
        /// Serialize the config object to JSON.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="serializer">The serializer to help serialize duh.</param>
        public void Serialize(JsonWriter writer, JsonSerializer serializer) {
            writer.WriteStartObject();

            //Don't put credentials if we shouldn't save them.
            if (RememberMe) {
                writer.WritePropertyName(UsernameJsonName);
                serializer.Serialize(writer, Username);

                writer.WritePropertyName(TokenJsonName);
                serializer.Serialize(writer, Token);
            }

            writer.WritePropertyName(RememberMeJsonName);
            serializer.Serialize(writer, RememberMe);

            writer.WriteEndObject();
        }
        #endregion
    }
}

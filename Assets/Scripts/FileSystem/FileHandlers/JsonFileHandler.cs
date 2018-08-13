using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Handler for loading and saving JSON based files
    /// to and fro the disk.
    /// /// </summary>
    public class JsonFileHandler : FileHandler<JsonFile> {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it can handle.
        /// </summary>
        public override FileType FileType => FileType.Json;

        /// <summary>
        /// The encoding that will be used for saving and loading
        /// text files.
        /// </summary>
        public Encoding Encoding { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new JSON file handler that uses utf8 encoding
        /// by default.
        /// </summary>
        public JsonFileHandler() {
            Encoding = Encoding.ASCII;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Load a JSON file from the disk.
        /// </summary>
        /// <param name="fileInfo">The path of where to load the
        /// file from.</param>
        /// <returns>The loaded JSON file.</returns>
        protected override async Task<JsonFile> LoadAsync(FileInfo fileInfo) {
            byte[] fileContent = await base.ReadFromFileAsync(fileInfo);
            string text = Encoding.GetString(fileContent);

            JObject fileJson = (JObject) JToken.Parse(text);
            return new JsonFile(fileInfo, fileJson);
        }

        /// <summary>
        /// Save a JSON file to disk.
        /// </summary>
        /// <param name="filePath">The path of where to save the file to.</param>
        /// <param name="file">The JSON based file to save.</param>
        protected override async Task SaveAsync(JsonFile file) {
            string jsonString = JsonConvert.SerializeObject(file.Content);
            byte[] fileContent = Encoding.GetBytes(jsonString);

            await base.WriteToFileAsync(file.Info, fileContent);
        }
        #endregion
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Handler for loading and saving JSON based files
    /// to and fro the disk.
    /// /// </summary>
    public class JsonFileHandler : FileHandler {
        #region Properties
        /// <summary>
        /// Indicator of what kind of file it can handle.
        /// </summary>
        public override FileType FileType => FileType.Json;

        /// <summary>
        /// The file extension that this handler supports.
        /// </summary>
        public override string FileExtension => "json";
        #endregion

        #region Helpers
        /// <summary>
        /// Load a JSON file from the disk.
        /// </summary>
        /// <param name="fileInfo">The path of where to load the
        /// file from.</param>
        /// <returns>The loaded JSON file.</returns>
        protected override async Task<IFile> LoadAsync(FileInfo fileInfo) {
            return await Task.Run(() => {
                using (StreamReader streamReader = File.OpenText(fileInfo.Path)) {
                    using (JsonTextReader reader = new JsonTextReader(streamReader)) {
                        JObject content = (JObject)JToken.ReadFrom(reader);
                        return new JsonFile(fileInfo, content);
                    }
                }
            });
        }

        /// <summary>
        /// Save a JSON file to disk.
        /// </summary>
        /// <param name="filePath">The path of where to save the file to.</param>
        /// <param name="file">The JSON based file to save.</param>
        protected override async Task SaveAsync(IFile file) {
            await Task.Run(() => {
                //File exists, wipe it first.
                if (File.Exists(file.Info.Path)) {
                    File.Delete(file.Info.Path);
                }

                using (StreamWriter streamWriter = File.CreateText(file.Info.Path)) {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(streamWriter, file);
                }
            });
        }
        #endregion
    }
}
using Newtonsoft.Json;
using NoMansBlocks.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.FileSystem {
    /// <summary>
    /// Handle for loading and saving .log files.
    /// </summary>
    public class LogFileHandler : FileHandler<LogFile> {
        #region Properties
        /// <summary>
        /// Indicator for what kind of files this handler supports.
        /// </summary>
        public override FileType FileType => FileType.Log;
        #endregion

        #region Helpers
        /// <summary>
        /// Load a log file from the disk.
        /// </summary>
        /// <param name="fileInfo">The path of where to load the file from.</param>
        /// <returns>The loaded log file.</returns>
        protected override async Task<LogFile> LoadAsync(FileInfo fileInfo) {
            byte[] fileContent = await base.ReadFromFileAsync(fileInfo);
            string jsonString = Encoding.UTF8.GetString(fileContent);

            List<LogStatement> content = JsonConvert.DeserializeObject<List<LogStatement>>(jsonString);
            return new LogFile(fileInfo, content);
        }

        /// <summary>
        /// Save a .log file to disk.
        /// </summary>
        /// <param name="file">The file to save.</param>
        protected override async Task SaveAsync(LogFile file) {
            string jsonString = JsonConvert.SerializeObject(file.Content);
            byte[] fileContent = Encoding.UTF8.GetBytes(jsonString);

            await base.WriteToFileAsync(file.Info, fileContent);
        }
        #endregion
    }
}

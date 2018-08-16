using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// A class containing
    /// </summary>
    [Serializable]
    public class SystemInfo {
        #region Properties
        /// <summary>
        /// The name of the computer running the game.
        /// </summary>
        public string ComputerName { get; set; }
        
        /// <summary>
        /// The model of the pc.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The type of operating system running.
        /// </summary>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// Information about the cpu running the game.
        /// </summary>
        public CpuInfo Cpu { get; set; }

        /// <summary>
        /// Information about the gpu running the game.
        /// </summary>
        public GpuInfo Gpu { get; set; }
        #endregion
    }
}

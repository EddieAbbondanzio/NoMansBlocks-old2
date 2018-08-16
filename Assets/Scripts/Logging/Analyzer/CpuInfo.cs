using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// Meta data about the cpu.
    /// </summary>
    [Serializable]
    public class CpuInfo {
        #region Properties
        /// <summary>
        /// If the Cpu is 32 bit, or 64 bit.
        /// </summary>
        public string Architecture { get; set; }

        /// <summary>
        /// The actual model of cpu.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// How fast the CPU is in MHZ.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// How many cores the cpu has.
        /// </summary>
        public int CoreCount { get; set; }
        #endregion
    }
}

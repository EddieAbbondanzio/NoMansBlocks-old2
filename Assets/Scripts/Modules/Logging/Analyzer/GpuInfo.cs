using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Logging {
        /// <summary>
        /// Information pertaining to the GPU.
        /// </summary>
        [Serializable]
    public class GpuInfo {
        #region Properties
        /// <summary>
        /// The make of the GPU card.
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// The model of the GPU card.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// How much memory the GPU has.
        /// </summary>
        public int MemorySize { get; set; }
        #endregion
    }
}

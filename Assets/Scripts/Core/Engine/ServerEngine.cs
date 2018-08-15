using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// A server instance of the no mans block game engine.
    /// </summary>
    public class ServerEngine : Engine {
        #region Properties
        /// <summary>
        /// Flag indicating what kind of engine it is.
        /// </summary>
        public override EngineType Type => EngineType.Server;
        #endregion
    }
}

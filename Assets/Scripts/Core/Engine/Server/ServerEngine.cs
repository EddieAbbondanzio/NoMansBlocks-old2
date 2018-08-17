using NoMansBlocks.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// A server instance of the no mans block game engine.
    /// </summary>
    public sealed class ServerEngine : GameEngine {
        #region Properties
        /// <summary>
        /// Flag indicating what kind of engine it is.
        /// </summary>
        public override EngineType Type => EngineType.Server;

        /// <summary>
        /// The network interface for working with others
        /// over the network.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 2)]
        public override NetModule NetModule { get; protected set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the server game engine.
        /// </summary>
        public ServerEngine() {
            NetModule = new NetModule(true, 16, 9505);
        }
        #endregion
    }
}

using NoMansBlocks.Network;
using NoMansBlocks.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// A client instance of the No Mans Block
    /// game engine.
    /// </summary>
    public sealed class ClientEngine : GameEngine {
        #region Properties
        /// <summary>
        /// Flag indicating what kind of engine it is.
        /// </summary>
        public override EngineType Type => EngineType.Client;

        /// <summary>
        /// The network interface for working with others
        /// over the network.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 2)]
        public override NetModule NetModule { get; protected set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the client game engine.
        /// </summary>
        public ClientEngine() {
            NetModule = new NetModule(false);
        }
        #endregion
    }
}

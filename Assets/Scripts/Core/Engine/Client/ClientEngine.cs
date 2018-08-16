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
    public class ClientEngine : GameEngine {
        #region Properties
        /// <summary>
        /// Flag indicating what kind of engine it is.
        /// </summary>
        public override EngineType Type => EngineType.Client;
        #endregion
    }
}

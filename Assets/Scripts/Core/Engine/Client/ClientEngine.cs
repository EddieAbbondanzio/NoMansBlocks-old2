using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// A client instance of the No Mans Block
    /// game engine.
    /// </summary>
    public sealed class ClientEngine : GameEngine {
        #region Properties
        /// <summary>
        /// Flag indicating what kind of engine it is.
        /// </summary>
        public override GameEngineType Type => GameEngineType.Client;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the game engine for a user
        /// that wants to play the game.
        /// </summary>
        public ClientEngine(IGameEngineTicker engineTicker) : base(engineTicker) {
            NetModule = new NetModule(this, 1, 0);
        }
        #endregion
    }
}

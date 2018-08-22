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
        public override EngineType Type => EngineType.Client;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the game engine for a user
        /// that wants to play the game.
        /// </summary>
        /// <param name="user">The user playing.</param>
        public ClientEngine(User user) : base(user) {
        }
        #endregion

        #region Engine Events
        /// <summary>
        /// Called when the engine is first starting up. This gets the
        /// modules ready, then pulls them all in.
        /// </summary>
        public override void Init() {
            NetModule = new NetModule(1, 0);
            base.Init();
        }
        #endregion
    }
}

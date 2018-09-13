using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.Config;
using NoMansBlocks.Modules.Network;
using NoMansBlocks.Modules.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine.Client {
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

        /// <summary>
        /// The configuration settings loaded in.
        /// </summary>
        //public ClientConfig Config { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the game engine for a user
        /// that wants to play the game.
        /// </summary>
        /// <param name="engineTicker">The engine game loop.</param>
        /// <param name="serviceLocator">The dependency injector.</param>
        public ClientEngine(IGameEngineTicker engineTicker, IServiceLocator serviceLocator) : base(engineTicker, serviceLocator) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// When the engine starts up load the login menu
        /// so the user can sign in.
        /// </summary>
        protected override void OnStart() {
            UIModule.LoadMenu<LoginMenu>(new LoginMenu());
        }
        #endregion 
    }
}

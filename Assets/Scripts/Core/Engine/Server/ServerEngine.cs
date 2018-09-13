﻿using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.Serialization;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Core.Engine.Server {
    /// <summary>
    /// A server instance of the no mans block game engine.
    /// </summary>
    public sealed class ServerEngine : GameEngine {
        #region Properties
        /// <summary>
        /// Flag indicating what kind of engine it is.
        /// </summary>
        public override GameEngineType Type => GameEngineType.Server;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the server game engine.
        /// <paramref name="engineTicker">The engine game loop.</paramref>
        /// </summary>
        /// <param name="engineTicker">The engine game loop.</param>
        /// <param name="serviceLocator">Dependency injector.</param>
        public ServerEngine(IGameEngineTicker engineTicker, IServiceLocator serviceLocator) : base(engineTicker, serviceLocator) {
        }
        #endregion
    }
}

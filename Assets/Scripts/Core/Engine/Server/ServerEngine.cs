using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.Serialization;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.Network;
using NoMansBlocks.Modules.UI.Menus;
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
        /// </summary>
        /// <param name="context">The engine's executing context.</param>
        /// <param name="serviceLocator">Dependency injector.</param>
        public ServerEngine(IContext context, IServiceLocator serviceLocator) : base(context, serviceLocator) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Generate the default user for the server.
        /// </summary>
        protected override void OnInit() {
            User.Current = new User("SERVER", PermissionLevel.Admin);
        }

        /// <summary>
        /// When the engine starts up, load the server menu so the
        /// user can see everything going on.
        /// </summary>
        protected override void OnStart() {
            UIModule.LoadMenu<ServerMenu>();
        }
        #endregion
    }
}

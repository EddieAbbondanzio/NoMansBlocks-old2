using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.Engine.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoMansBlocks.Core.Engine.Server {
    /// <summary>
    /// Server module for running the game engine
    /// as a server.
    /// </summary>
    [RequireComponent(typeof(UnityContext))]
    public class ServerBehaviour : MonoBehaviour {
        #region Properties
        /// <summary>
        /// Instance of the game engine running as a server.
        /// </summary>
        public ServerEngine Engine { get; private set; }
        #endregion

        #region Mono Events
        /// <summary>
        /// Prepares the engine for use.
        /// </summary>
        private void Start() {
            DontDestroyOnLoad(this.gameObject);

            IContext context = GetComponent<IContext>();
            Engine = new ServerEngine(context, new UnityServiceLocator());
            Engine.Run();
        }
        #endregion
    }
}

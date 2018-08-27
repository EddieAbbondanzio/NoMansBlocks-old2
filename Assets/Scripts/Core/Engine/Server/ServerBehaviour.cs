using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Server module for running the game engine
    /// as a server.
    /// </summary>
    [RequireComponent(typeof(UnityEngineTicker))]
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
        private void Awake() {
            if (GameObject.FindGameObjectsWithTag("ScriptsObject")?.Length > 1) {
                throw new Exception("More than one instance of the game engine has been found!");
            }

            DontDestroyOnLoad(this.gameObject);

            IGameEngineTicker engineTicker = GetComponent<IGameEngineTicker>();
            Engine = new ServerEngine(engineTicker);
            Engine.Run();
        }
        #endregion
    }
}

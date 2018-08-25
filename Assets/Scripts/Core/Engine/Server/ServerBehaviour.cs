using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Server module for running the game engine
    /// as a server.
    /// </summary>
    public class ServerBehaviour : MonoBehaviour {
        #region Properties
        /// <summary>
        /// Instance of the game engine running as a server.
        /// </summary>
        public ServerEngine Engine { get; private set; }

        /// <summary>
        /// The maximum number of clients allowed to connect.
        /// </summary>
        [Range(4, 32)]
        public int Capacity = 4;

        /// <summary>
        /// The port number to use the server on.
        /// </summary>
        public int Port = 9050;
        #endregion

        #region Mono Events
        /// <summary>
        /// Prepares the engine for use.
        /// </summary>
        private void Awake() {
            if (GameObject.FindGameObjectsWithTag("ScriptsObject")?.Length > 1) {
                throw new System.Exception("More than one instance of the game engine has been found!");
            }

            DontDestroyOnLoad(this.gameObject);

            Engine = new ServerEngine(Capacity, Port);
            Engine.Init();
        }

        /// <summary>
        /// Called after everything has been initialized.
        /// </summary>
        private void Start() {
            Engine.Start();
        }

        /// <summary>
        /// Called every tick of the game.
        /// </summary>
        private void Update() {
            Engine.Update();
        }

        /// <summary>
        /// Called when the engine is shutting down.
        /// </summary>
        private void OnApplicationQuit() {
            Engine.End();
        }
        #endregion
    }
}

using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// MonoBehaviour to run the engine as a client.
    /// </summary>
    public class ClientBehaviour : MonoBehaviour {
        #region Properties
        /// <summary>
        /// The instance of the No Mans Blocks Engine.
        /// </summary>
        public ClientEngine Engine { get; private set; }
        #endregion

        #region Mono Events
        /// <summary>
        /// Prepares the engine for use.
        /// </summary>
        private void Awake() {
            if(GameObject.FindGameObjectsWithTag("ScriptsObject")?.Length > 1) {
                throw new System.Exception("More than one instance of the game engine has been found!");
            }

            DontDestroyOnLoad(this.gameObject);

            Engine = new ClientEngine();
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

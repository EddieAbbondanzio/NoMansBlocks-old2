using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.UI.Menus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoMansBlocks.Core.Engine.Client {
    /// <summary>
    /// MonoBehaviour to run the engine as a client.
    /// </summary>
    [RequireComponent(typeof(UnityEngineTicker))]
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
            Debug.Log(SystemInfo.deviceUniqueIdentifier);

            if(GameObject.FindGameObjectsWithTag("ScriptsObject")?.Length > 1) {
                throw new Exception("More than one instance of the game engine has been found!");
            }

            DontDestroyOnLoad(this.gameObject);

            IGameEngineTicker engineTicker = GetComponent<IGameEngineTicker>();
            Engine = new ClientEngine(engineTicker);

            Engine.Run();
        }
        #endregion
    }
}

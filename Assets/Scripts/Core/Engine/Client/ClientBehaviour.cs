﻿using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.Input;
using NoMansBlocks.Modules.Input.Devices;
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
            DontDestroyOnLoad(this.gameObject);

            IGameEngineTicker engineTicker = GetComponent<IGameEngineTicker>();
            Engine = new ClientEngine(engineTicker, new UnityServiceLocator());
            Engine.Run();
        }
        #endregion
    }
}

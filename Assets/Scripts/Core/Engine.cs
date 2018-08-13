using NoMansBlocks.FileSystem;
using NoMansBlocks.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Core {
    /// <summary>
    /// The core of the game engine. This should be the 
    /// only monobehaviour used in the entire engine.
    /// </summary>
    public class Engine : MonoBehaviour {
        #region Properties
        /// <summary>
        /// The singleton instance of the engine. There
        /// can only ever be one!
        /// </summary>
        private static Engine Instance { get; set; }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Called before the engine is started. When things
        /// are just getting warmed up
        /// </summary>
        public static EventHandler OnAwake;

        /// <summary>
        /// Called when the engine is first starting up.
        /// </summary>
        public static EventHandler OnStart;

        /// <summary>
        /// Called whenever the engine makes a tick.
        /// </summary>
        public static EventHandler OnUpdate;

        /// <summary>
        /// Called when the engine is shutting down.
        /// </summary>
        public static EventHandler OnStop;
        #endregion

        #region Mono Events
        /// <summary>
        /// Called right off the bat when Unity first starts.
        /// </summary>
        private void Awake() {
            if (Instance != null) {
                throw new Exception("Engine.Awake(): Instance was already set! Two Engine instances?");
            } else {
                Instance = this;
            }

            //Fire off the awake event.
            if (OnAwake != null) {
                OnAwake(this, null);
            }
        }

        /// <summary>
        /// Called after things have initialized and
        /// we are ready to go!
        /// </summary>
        private void Start() {
            //First off the start event.
            if (OnStart != null) {
                OnStart(this, null);
            }

            Log.Debug("FUCK YOU MAN");
            Log.Warn("This is a warning");
            Log.Error("This is an error!");
        }

        /// <summary>
        /// Called every update tick of Unity.
        /// </summary>
        private void Update() {
            if(OnUpdate != null) {
                OnUpdate(this, null);
            }
        }

        /// <summary>
        /// Called when the application or editor is closing down.
        /// </summary>
        private void OnApplicationQuit() {
            if (OnStop != null) {
                OnStop(this, null);
            }
        }
        #endregion
    }
}
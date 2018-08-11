using NoMansBlocks.FileSystem;
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
        public static Engine Instance { get; private set; }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Called before the engine is started. When things
        /// are just getting warmed up
        /// </summary>
        public EventHandler OnAwake;

        /// <summary>
        /// Called when the engine is first starting up.
        /// </summary>
        public EventHandler OnStart;

        /// <summary>
        /// Called when the engine is shutting down.
        /// </summary>
        public EventHandler OnStop;
        #endregion

        #region Mono Events
        /// <summary>
        /// Called right off the bat when Unity first starts.
        /// </summary>
        private void Awake() {
            Debug.Log(Environment.CurrentDirectory);

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

        // Use this for initialization
        private async void Start() {
            FileInfo fileInfo = new FileInfo("C:\\Users\\Eddie\\Desktop\\test.json");

            JsonFile testFile = await FileIO.LoadAsync(fileInfo) as JsonFile;

            int cat = 4;

            //First off the start event.
            if (OnStart != null) {
                OnStart(this, null);
            }
        }

        // Update is called once per frame
        private void Update() {

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
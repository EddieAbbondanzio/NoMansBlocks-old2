using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Unity based game engine ticker.
    /// </summary>
    public class UnityEngineTicker : MonoBehaviour, IGameEngineTicker {
        #region Members
        /// <summary>
        /// If we are active right now.
        /// </summary>
        private bool isTicking;
        #endregion

        #region Event Delegates
        /// <summary>
        /// The on init phase.
        /// </summary>
        public event EventHandler OnInit;

        /// <summary>
        /// The start phase of the engine.
        /// </summary>
        public event EventHandler OnStart;

        /// <summary>
        /// An update tick of the engine.
        /// </summary>
        public event EventHandler OnUpdate;

        /// <summary>
        /// When the engine is shutting down.
        /// </summary>
        public event EventHandler OnEnd;
        #endregion

        #region Mono Events
        /// <summary>
        /// Prepares the engine for use.
        /// </summary>
        private void Awake() {
            if (GameObject.FindGameObjectsWithTag("ScriptsObject")?.Length > 1) {
                throw new Exception("More than one instance of the game engine has been found!");
            }
        }

        /// <summary>
        /// Called every tick of the game.
        /// </summary>
        private void Update() {
            if (isTicking && OnUpdate != null) {
                OnUpdate(this, null);
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Start running the ticker.
        /// </summary>
        public void StartTicking() {
            if (isTicking) {
                throw new InvalidOperationException("Run has already been called. Cannot call twice!");
            }

            isTicking = true;

            if (OnInit != null) {
                OnInit(this, null);
            }

            if (OnStart != null) {
                OnStart(this, null);
            }
        }

        /// <summary>
        /// Stop ticking.
        /// </summary>
        public void StopTicking() {
            if (!isTicking) {
                throw new InvalidOperationException("Cannot stop the ticker as it's not running.");
            }

            if (OnEnd != null) {
                OnEnd(this, null);
            }

            isTicking = false;
        }
        #endregion

    }
}
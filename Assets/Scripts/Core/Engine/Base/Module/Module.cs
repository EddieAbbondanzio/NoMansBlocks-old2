using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Base class for Modules to derive from. Modules are components of
    /// the engine that require tracking their state, etc... 
    /// </summary>
    public abstract class Module {
        #region Properties
        /// <summary>
        /// The instance of the engine that is running
        /// this module.
        /// </summary>
        protected GameEngine Engine { get; set; }

        /// <summary>
        /// What position in the module array this is. This
        /// is set using the ModuleExecutionAttribute.
        /// </summary>
        public byte ExecutionIndex { get; set; }

        /// <summary>
        /// If the Update() method of the module should be called.
        /// </summary>
        public bool DisableUpdate { get; set; }

        /// <summary>
        /// If the module is enabled, and running.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// If the module is running in debug mode.
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// The mode we are currently executing in.
        /// </summary>
        public GameEngineType EngineType { get { return Engine.Type; } }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of a module. The Game engine that
        /// owns the module is an expected dependency to take advantage
        /// of communicating with other modules.
        /// </summary>
        /// <param name="engine">The engine running the module.</param>
        protected Module(GameEngine engine) {
            Engine = engine;

            ExecutionIndex = byte.MaxValue;
            DisableUpdate  = false;
            Enabled        = true;
        }
        #endregion

        #region Lifecycle Events
        /// <summary>
        /// Called when the engine is first starting up. Use this
        /// to prepare local stuff but don't access other modules yet.
        /// </summary>
        public virtual void OnInit() {
        }

        /// <summary>
        /// Called after everything has been initialized. Now it's
        /// safe to access other modules.
        /// </summary>
        public virtual void OnStart() {
        }

        /// <summary>
        /// Fired every tick of the engine. Use this sparingly to 
        /// preserve performance.
        /// </summary>
        public virtual void OnUpdate() {
        }

        /// <summary>
        /// Fired when the engine is shutting down. Use this to save
        /// state, etc...
        /// </summary>
        public virtual void OnEnd() {
        }

        /// <summary>
        /// Fired right after a new scene has been loaded into the
        /// game.
        /// </summary>
        /// <param name="scene">The newly loaded scene</param>
        public virtual void OnSceneLoaded(Scene scene) {
        }

        /// <summary>
        /// Fired right before a scene is unloaded.
        /// </summary>
        /// <param name="scene">The scene being unloaded.</param>
        public virtual void OnSceneDestroyed(Scene scene) {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Search for another module that is associated with this module's
        /// parent via it's type.
        /// </summary>
        /// <typeparam name="T">The type of module to return.</typeparam>
        /// <returns>The module found (if any).</returns>
        protected T GetModule<T>() where T : Module {
            return Engine.GetModule<T>();
        }

        /// <summary>
        /// Search for a service from the game engine. This is simply
        /// a shortcut to Engine.GetService().
        /// </summary>
        /// <typeparam name="T">The type of service to look for.</typeparam>
        /// <returns>The service found.</returns>
        protected T GetService<T>() where T : class, IService {
            return Engine.GetService<T>();
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Log a debug statement to the console if the module is running in
        /// debug mode. Else skip over it. This accepts strings in the form
        /// of string.format().
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="parameters">The parameters to add if any.</param>
        protected void Debug(string message, params object[] parameters) {
            if (DebugMode) {
                Log.Debug(message, parameters);
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Base class for Modules to derive from. Modules are components of
    /// the engine that require tracking their state, etc... 
    /// </summary>
    public abstract class Module : IEngineCycleListener {
        #region Properties
        /// <summary>
        /// The container that owns this module.
        /// </summary>
        public GameEngine Engine { get; set; }

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
        /// The mode we are currently executing in.
        /// </summary>
        public EngineType EngineType { get { return Engine.Type; } }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new module for the engine.
        /// </summary>
        protected Module() {
            ExecutionIndex = byte.MaxValue;
            DisableUpdate  = false;
            Enabled        = true;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Search for another module that is associated with this module's
        /// parent via it's type.
        /// </summary>
        /// <typeparam name="T">The type of module to return.</typeparam>
        /// <returns>The module found (if any).</returns>
        public T GetModule<T>() where T : Module {
            return Engine?.GetModule<T>() ?? null;
        }

        /// <summary>
        /// Called when the engine is first starting up. Use this
        /// to prepare local stuff but don't access other modules yet.
        /// </summary>
        public virtual void OnInit() {
        }

        /// <summary>
        /// Initialize the module first before initializing
        /// </summary>
        public virtual void Init() {
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
        #endregion
    }
}

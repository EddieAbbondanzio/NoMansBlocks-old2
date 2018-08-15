using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Base class for Modules to derive from. Modules are components of
    /// the engine that require tracking their state, etc... 
    /// </summary>
    public abstract class Module : IEngineCycleListener {
        #region Properties
        /// <summary>
        /// What position in the module array this is. This
        /// is set using the ModuleExecutionAttribute.
        /// </summary>
        public byte ExecutionIndex { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new module for the engine.
        /// </summary>
        protected Module() {
            ExecutionIndex = byte.MaxValue;
        }
        #endregion

        #region Publics
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

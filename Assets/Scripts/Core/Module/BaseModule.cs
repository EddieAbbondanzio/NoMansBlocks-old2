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
    public abstract class BaseModule : BaseContainer<BaseComponent>, IEngineCycleListener {
        #region Properties

        #endregion

        #region Constructor(s)
        protected BaseModule() {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Called when the engine is first starting up. Use this
        /// to prepare local stuff but don't access other modules yet.
        /// </summary>
        public void OnInit() {
            Init();

            if (Members != null) {
                for (int i = 0; i < Members.Length; i++) {
                    Members[i].OnInit();
                }
            }
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
        public void OnStart() {
            if (Members != null) {
                for (int i = 0; i < Members.Length; i++) {
                    Members[i].OnStart();
                }
            }
        }

        /// <summary>
        /// Fired every tick of the engine. Use this sparingly to 
        /// preserve performance.
        /// </summary>
        public void OnUpdate() {
            if (Members != null) {
                for (int i = 0; i < Members.Length; i++) {
                    Members[i].OnUpdate();
                }
            }
        }

        /// <summary>
        /// Fired when the engine is shutting down. Use this to save
        /// state, etc...
        /// </summary>
        public void OnEnd() {
            if (Members != null) {
                for (int i = 0; i < Members.Length; i++) {
                    Members[i].OnEnd();
                }
            }
        }
        #endregion
    }
}

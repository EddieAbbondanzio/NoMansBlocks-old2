using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Interface to represent an object that listens in on the 
    /// engine life cycle events.
    /// </summary>
    public interface IEngineCycleListener {
        #region Publics
        /// <summary>
        /// Called when the engine is first starting up. Use this
        /// to prepare local stuff but don't access other modules yet.
        /// </summary>
        void OnInit();

        /// <summary>
        /// Called after everything has been initialized. Now it's
        /// safe to access other modules.
        /// </summary>
        void OnStart();

        /// <summary>
        /// Fired every tick of the engine. Use this sparingly to 
        /// preserve performance.
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// Fired when the engine is shutting down. Use this to save
        /// state, etc...
        /// </summary>
        void OnEnd();
        #endregion
    }
}

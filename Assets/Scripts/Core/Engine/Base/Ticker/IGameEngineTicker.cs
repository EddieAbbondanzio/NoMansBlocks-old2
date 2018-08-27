using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Interface to represent the core of a Game Engine
    /// that handles firing off the various life cycle
    /// events.
    /// </summary>
    public interface IGameEngineTicker {
        #region Events
        /// <summary>
        /// Fired off when the engine is just starting.
        /// Use this to initialize anything local, that 
        /// doesn't rely on anything else.
        /// </summary>
        event EventHandler OnInit;

        /// <summary>
        /// Fired off after everything has been initialized.
        /// Now it is safe to access other modules or resources.
        /// </summary>
        event EventHandler OnStart;

        /// <summary>
        /// Fired off every update tick of the engine. This is
        /// used to perform rendering updates, etc..
        /// </summary>
        event EventHandler OnUpdate;

        /// <summary>
        /// Fired off when the engine is shutting down. Use this to
        /// save off the log file, or release resources.
        /// </summary>
        event EventHandler OnEnd;
        #endregion

        #region Publics
        /// <summary>
        /// Start up the engine and begin firing off the life 
        /// cycle events.
        /// </summary>
        void StartTicking();

        /// <summary>
        /// Stop calling the update tick and fire off the OnEnd
        /// event.
        /// </summary>
        void StopTicking();
        #endregion
    }
}

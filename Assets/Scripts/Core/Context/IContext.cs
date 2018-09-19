using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Context to check the current execution state 
    /// of the game engine.
    /// </summary>
    public interface IContext {
        #region Properties
        /// <summary>
        /// The game engine ticker that fires off start,
        /// update, end, etc
        /// </summary>
        IGameEngineTicker EngineTicker { get; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired off when an unhandled exception occurs.
        /// </summary>
        event UnhandledExceptionEventHandler OnUnhandledException;
        #endregion

        #region Publics
        /// <summary>
        /// Checks if the currently executing thread is
        /// the main Unity thread.
        /// </summary>
        /// <returns></returns>
        bool IsCurrentThreadMain();

        /// <summary>
        /// Excecute the passed in task on the main
        /// Unity thread.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        void ExecuteOnMain(Action action);
        #endregion
    }
}

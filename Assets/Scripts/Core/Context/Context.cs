using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Context of the currently executing engine.
    /// </summary>
    public static class Context {
        #region Members
        /// <summary>
        /// The current engine context.
        /// </summary>
        private static IContext currentContext;
        #endregion

        #region Publics
        /// <summary>
        /// Set the current context of the engine.
        /// </summary>
        /// <param name="context">The context that is active.</param>
        public static void SetContext(IContext context) {
            if(currentContext != null) {
                throw new Exception("Engine context has already been set!");
            }

            currentContext = context;
        }

        /// <summary>
        /// Checks if the thread that called this method
        /// is the main Unity thread.
        /// </summary>
        /// <returns>True if running on the main thread.</returns>
        public static bool IsCurrentThreadMain() {
            return currentContext.IsCurrentThreadMain();
        }

        /// <summary>
        /// Excecute the passed in task on the main
        /// Unity thread.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public static void ExecuteOnMain(Action action) {
            currentContext.ExecuteOnMain(action);
        }
        #endregion
    }
}

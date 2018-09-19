using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Unity specific executing context.
    /// </summary>
    [RequireComponent(typeof(UnityEngineTicker))]
    public sealed class UnityContext : MonoBehaviour, IContext {
        #region Properties
        /// <summary>
        /// The main game loop responsible for
        /// firing out updates.
        /// </summary>
        public IGameEngineTicker EngineTicker { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The list of tasks waiting to be executed.
        /// </summary>
        private TQueue<Action> actionQueue;

        /// <summary>
        /// The thread that unity is executing on.
        /// </summary>
        private Thread mainThead;
        #endregion

        #region Event Delegates
        /// <summary>
        /// Event fired off anytime an exception occurs and nothing caught it.
        /// </summary>
        public event UnhandledExceptionEventHandler OnUnhandledException {
            add { AppDomain.CurrentDomain.UnhandledException += value; }
            remove { AppDomain.CurrentDomain.UnhandledException -= value; }
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Pulls in the currently executing thread so we
        /// always have a reference back to it.
        /// </summary>
        private void Awake() {
            actionQueue  = new TQueue<Action>();
            mainThead    = Thread.CurrentThread;
            EngineTicker = GetComponent<IGameEngineTicker>();
        }

        /// <summary>
        /// Invoke any actions that may have accumulated.
        /// </summary>
        private void Update() {
            while(actionQueue.Count > 0) {
                actionQueue.Dequeue()();
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Checks if the currently executing thread is the 
        /// Unity main thread.
        /// </summary>
        /// <returns>True if the caller of this method is
        /// running on the main thread.</returns>
        public bool IsCurrentThreadMain() {
            return mainThead.Equals(Thread.CurrentThread);
        }

        /// <summary>
        /// Excecute the passed in action on the main 
        /// thread.
        /// </summary>
        /// <param name="action">The action to call on the main thread.</param>
        public void ExecuteOnMain(Action action) {
            actionQueue.Enqueue(action);
        }
        #endregion
    }
}

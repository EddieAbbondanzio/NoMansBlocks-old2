using NoMansBlocks.Logging;
using NoMansBlocks.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Instance of the game engine. This handles updating and managing
    /// all of it's components.
    /// </summary>
    public abstract class GameEngine : ModuleContainer {
        #region Properties
        /// <summary>
        /// If the engine is a client or server instance.
        /// </summary>
        public abstract EngineType Type { get; }

        /// <summary>
        /// The module used to handle logging to console and
        /// building useful log files.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 0, DisableUpdate = true)]
        public LogModule LogModule { get; private set; }

        /// <summary>
        /// The module used to interface with the network.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 1)]
        public NetModule NetModule { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new base instance of the
        /// game engine.
        /// </summary>
        protected GameEngine() {
            LogModule = new LogModule();
            NetModule = new NetModule();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Fires off the init event for every single module
        /// associated with the engine.
        /// </summary>
        public void Init() {
            base.FindModules();
            base.InitModules();
        }

        /// <summary>
        /// Called when the engine has initialized. Alert the modules.
        /// </summary>
        public void Start() {
            base.StartModules();
        }

        /// <summary>
        /// Called every tick of the engine. Update every single module
        /// </summary>
        public void Update() {
            base.UpdateModules();
        }

        /// <summary>
        /// Called when the engine is stopping. Alert every module.
        /// </summary>
        public void End() {
            base.EndModules();
        }
        #endregion
    }
}

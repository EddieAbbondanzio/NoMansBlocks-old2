using NoMansBlocks.Logging;
using NoMansBlocks.Modules.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Modules.CommandConsole;
using NoMansBlocks.Modules.Network;
using NoMansBlocks.Core.UserSystem;
using System.Reflection;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Instance of the game engine. This handles updating and managing
    /// all of it's components.
    /// </summary>
    public abstract class GameEngine {
        #region Properties
        /// <summary>
        /// If the engine is a client or server instance.
        /// </summary>
        public abstract EngineType Type { get; }

        /// <summary>
        /// The user running the engine.
        /// </summary>
        public IUser User { get; }

        /// <summary>
        /// The module used to handle logging to console and
        /// building useful log files.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 0, DisableUpdate = true)]
        public LogModule LogModule { get; private set; }

        /// <summary>
        /// Processes inputs for commands from the user.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 1, DisableUpdate = true)]
        public CommandConsoleModule CommandModule { get; private set; }

        /// <summary>
        /// The module used to interface with the network.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 2)]
        public NetModule NetModule { get; protected set; }
        #endregion

        #region Members
        /// <summary>
        /// The collection of modules that belong to the engine.
        /// This should never be interacted with directly.
        /// </summary>
        private Module[] modules;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the game engine. A user
        /// is required to know how to run the engine.
        /// </summary>
        /// <param name="user">The user running the game.</param>
        protected GameEngine(IUser user) {
            User = user;

            LogModule     = new LogModule();
            CommandModule = new CommandConsoleModule();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Fires off the init event for every single module
        /// associated with the engine.
        /// </summary>
        public virtual void Init() {
            //Find the modules
            PropertyInfo[] memberProperties = this.GetType().GetProperties().Where(p => p.PropertyType.IsSubclassOf(typeof(Module)) || p.PropertyType == typeof(Module)).ToArray();
            modules = new Module[memberProperties.Length];

            for (int i = 0; i < memberProperties.Length; i++) {
                modules[i] = memberProperties[i].GetValue(this) as Module;
                modules[i].Engine = this;

                //If a module has a custom execution index, pull it in.
                ModuleExecutionAttribute executionAttribute = memberProperties[i].GetCustomAttribute<ModuleExecutionAttribute>();
                if (executionAttribute != null) {
                    //Set the execution index, and disable update here.
                    modules[i].ExecutionIndex = executionAttribute.ExecutionIndex;
                    modules[i].Enabled = executionAttribute.Enabled;
                    modules[i].DisableUpdate = executionAttribute.DisableUpdate;
                }
            }

            //Lastly we order by execution index
            modules = modules.OrderBy(m => m.ExecutionIndex).ToArray();

            //Init the modules.
            if (modules != null) {
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i].Enabled) {
                        modules[i].OnInit();
                    }
                }
            }
        }

        /// <summary>
        /// Called when the engine has initialized. Alert the modules.
        /// </summary>
        public virtual void Start() {
            if (modules != null) {
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i].Enabled) {
                        modules[i].OnStart();
                    }
                }
            }
        }

        /// <summary>
        /// Called every tick of the engine. Update every single module
        /// </summary>
        public virtual void Update() {
            if (modules != null) {
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i].Enabled && !modules[i].DisableUpdate) {
                        modules[i].OnUpdate();
                    }
                }
            }
        }

        /// <summary>
        /// Called when the engine is stopping. Alert every module.
        /// </summary>
        public virtual void End() {
            if (modules != null) {
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i].Enabled) {
                        modules[i].OnEnd();
                    }
                }
            }
        }

        /// <summary>
        /// Retrieve a module via it's type.
        /// </summary>
        /// <typeparam name="T">The type (or base type) of module to look for.</typeparam>
        /// <returns>The module found (if any).</returns>
        public T GetModule<T>() where T : Module {
            for (int i = 0; i < modules.Length; i++) {
                Type moduleType = modules[i].GetType();

                if (moduleType == typeof(T) || moduleType.IsSubclassOf(typeof(T))) {
                    return modules[i] as T;
                }
            }

            return null;
        }
        #endregion
    }
}

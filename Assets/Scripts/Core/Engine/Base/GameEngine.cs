using NoMansBlocks.Logging;
using NoMansBlocks.Modules.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMansBlocks.Modules.CommandConsole;
using NoMansBlocks.Modules.Network;
using System.Reflection;
using NoMansBlocks.Modules.UI;
using UnityEngine.SceneManagement;
using NoMansBlocks.Modules.Config;
using UnityEngine;
using NoMansBlocks.Modules.Input;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Instance of the game engine. This handles updating and managing
    /// all of it's components.
    /// </summary>
    public abstract class GameEngine {
        #region Statics
        /// <summary>
        /// Reference to ensure only 1 instance is running at any time.
        /// </summary>
        private static GameEngine instance;
        #endregion

        #region Properties
        /// <summary>
        /// If the engine is a client or server instance.
        /// </summary>
        public abstract GameEngineType Type { get; }

        /// <summary>
        /// If the engine is currently running or not.
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// The module that holds all of the config settings
        /// </summary>
        [ModuleExecution(ExecutionIndex = 0, DisableUpdate = true)]
        public ConfigModule ConfigModule { get; private set; }

        /// <summary>
        /// The module used to handle logging to console and
        /// building useful log files.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 1, DisableUpdate = true)]
        public LogModule LogModule { get; private set; }

        /// <summary>
        /// Processes inputs for commands from the user.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 2, DisableUpdate = true)]
        public CommandConsoleModule CommandModule { get; private set; }

        /// <summary>
        /// The module that handles loading scenes.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 3, DisableUpdate = true)]
        public UIModule UIModule { get; private set; }

        /// <summary>
        /// The module used to interface with the network.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 4)]
        public NetModule NetModule { get; protected set; }

        /// <summary>
        /// Handles retrieving inputs from the user via various
        /// controllers such as the keyboard, and mouse.
        /// </summary>
        [ModuleExecution(ExecutionIndex = 5)]
        public InputModule InputModule { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// Dependency injection for the engine.
        /// </summary>
        private IServiceLocator serviceLocator;

        /// <summary>
        /// Handles firing off the events of the game engine.
        /// </summary>
        private IGameEngineTicker engineTicker;

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
        /// <param name="engineTicker">The main game loop.</param>
        /// <param name="serviceLocator">The dependency locator.</param>
        protected GameEngine(IGameEngineTicker engineTicker, IServiceLocator serviceLocator) {
            if(instance != null) {
                throw new Exception("Two or more instances of the game engine exist!");
            }

            this.engineTicker   = engineTicker;
            this.serviceLocator = serviceLocator;

            LogModule     = new LogModule(this, serviceLocator.GetLogger());
            ConfigModule  = new ConfigModule(this);
            CommandModule = new CommandConsoleModule(this);
            UIModule      = new UIModule(this);
            NetModule     = new NetModule(this);
            InputModule   = new InputModule(this, serviceLocator.GetInputPoller());

            this.engineTicker.OnInit   += OnTickerInit;
            this.engineTicker.OnStart  += OnTickerStart;
            this.engineTicker.OnUpdate += OnTickerUpdate;
            this.engineTicker.OnEnd    += OnTickerEnd;

            SceneManager.sceneLoaded   += SceneManagerSceneLoaded;
            instance = this;
        }

        /// <summary>
        /// Free up resources by unsubbing from the
        /// ticker events.
        /// </summary>
        ~GameEngine() {
            engineTicker.OnInit   -= OnTickerInit;
            engineTicker.OnStart  -= OnTickerStart;
            engineTicker.OnUpdate -= OnTickerUpdate;
            engineTicker.OnEnd    -= OnTickerEnd;

            SceneManager.sceneLoaded   -= SceneManagerSceneLoaded;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Start up the engine. This fires off the init
        /// event, and gets things moving.
        /// </summary>
        public void Run() {
            if(IsRunning) {
                throw new InvalidOperationException("Engine is already running! Cannot call Run() twice.");
            }

            engineTicker.StartTicking();
            IsRunning = true;
        }

        /// <summary>
        /// Stop the engine. Deallocate resources and shut
        /// down the modules.
        /// </summary>
        public void Stop() {
            if (!IsRunning) {
                throw new InvalidOperationException("Engine is not running. Cannot stop it.");
            }

            engineTicker.StopTicking();
            IsRunning = false;

#if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        /// <summary>
        /// Load a scene via it's unique name.
        /// </summary>
        /// <param name="name">The name of the scene to load.</param>
        public void LoadScene(string name) {
            Scene scene = SceneManager.GetActiveScene();
            OnSceneDestroyed(scene);

            for (int i = 0; i < modules.Length; i++) {
                modules[i].OnSceneDestroyed(scene);
            }

            SceneManager.LoadScene(name);
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

        #region Life Cycle Events
        /// <summary>
        /// Override this to do any work needed for the engine when
        /// things are just getting ready.
        /// </summary>
        protected virtual void OnInit() {
        }

        /// <summary>
        /// Override this to do any work needed that may rely on
        /// something else.
        /// </summary>
        protected virtual void OnStart() {
        }

        /// <summary>
        /// Override this to perform work every single update tick
        /// of the game engine.
        /// </summary>
        protected virtual void OnUpdate() {
        }

        /// <summary>
        /// Override this to do any cleaning up needed when the
        /// engine is shutting down.
        /// </summary>
        protected virtual void OnEnd() {
        }

        /// <summary>
        /// Override this to do any work right after a new
        /// scene is loaded into the game.
        /// </summary>
        protected virtual void OnSceneLoaded(Scene scene) {

        }

        /// <summary>
        /// Override this to do any work right before a scene
        /// is unloaded.
        /// </summary>
        protected virtual void OnSceneDestroyed(Scene scene) {

        }
        #endregion

        #region Helpers
        /// <summary>
        /// Initialize the engine and get things ready to roll.
        /// </summary>
        /// <param name="sender">The ticker.</param>
        /// <param name="e">Always null.</param>
        private void OnTickerInit(object sender, EventArgs e) {
            //Find the modules
            PropertyInfo[] memberProperties = this.GetType().GetProperties().Where(p => p.PropertyType.IsSubclassOf(typeof(Module)) || p.PropertyType == typeof(Module)).ToArray();
            modules = new Module[memberProperties.Length];

            for (int i = 0; i < memberProperties.Length; i++) {
                modules[i] = memberProperties[i].GetValue(this) as Module;

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

            OnInit();

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
        /// Start up the engine.
        /// </summary>
        /// <param name="sender">The ticker.</param>
        /// <param name="e">Always null.</param>
        private void OnTickerStart(object sender, EventArgs e) {
            OnStart();

            if (modules != null) {
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i].Enabled) {
                        modules[i].OnStart();
                    }
                }
            }
        }

        /// <summary>
        /// Update the engine by 1 tick.
        /// </summary>
        /// <param name="sender">The ticker.</param>
        /// <param name="e">Always null.</param>
        private void OnTickerUpdate(object sender, EventArgs e) {
            OnUpdate();

            if (modules != null) {
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i].Enabled && !modules[i].DisableUpdate) {
                        modules[i].OnUpdate();
                    }
                }
            }
        }

        /// <summary>
        /// Stop the engine. Free up resources.
        /// </summary>
        /// <param name="sender">The ticker.</param>
        /// <param name="e">Always null.</param>
        private void OnTickerEnd(object sender, EventArgs e) {
            OnEnd();

            if (modules != null) {
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i].Enabled) {
                        modules[i].OnEnd();
                    }
                }
            }
        }

        /// <summary>
        /// Fired off everytime a new scene is loaded.
        /// </summary>
        /// <param name="arg0">The scene that was loaded.</param>
        /// <param name="arg1">How it was loaded.</param>
        private void SceneManagerSceneLoaded(Scene arg0, LoadSceneMode arg1) {
            OnSceneLoaded(arg0);

            for(int i = 0; i < modules.Length; i++) {
                modules[i].OnSceneLoaded(arg0);
            }
        }
        #endregion
    }
}

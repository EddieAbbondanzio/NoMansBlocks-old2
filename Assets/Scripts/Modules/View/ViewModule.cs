using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// Module responsible for loading and handling the
    /// various views of the engine.
    /// </summary>
    public class ViewModule : Core.Engine.Module {
        #region Properties
        /// <summary>
        /// The view currently loaded.
        /// </summary>
        public GameView ActiveView { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The available for 
        /// </summary>
        private List<GameView> views;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the view module. This is
        /// responsible for everything UI related.
        /// </summary>
        /// <param name="engine">The engine that owns the module.</param>
        public ViewModule(GameEngine engine) : base(engine) {
        }

        /// <summary>
        /// Prevent memory leaks.
        /// </summary>
        ~ViewModule() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        #endregion

        #region Module Events
        /// <summary>
        /// Initialize the module by searching for every GameView associated
        /// with this engine type and creating an instance of it in the cache.
        /// Then attempt to figure out the current view so we can load the menus
        /// on it.
        /// </summary>
        /// <exception cref="Exception">When an unknown scene is started, and
        /// we can't figure out where we are.</exception>
        public override void OnInit() {
            views = new List<GameView>();

            //Find the possible view types.
            List<Type> viewTypes = Assembly.GetAssembly(typeof(GameView)).GetTypes().Where(t => t.IsSubclassOf(typeof(GameView))).ToList();

            //Now make an instance of each one
            foreach(Type viewType in viewTypes) {
                GameView view = Activator.CreateInstance(viewType, this) as GameView;

                //Only add the view if it supports this engine type
                if(view.Type == Engine.Type) {
                    views.Add(view);
                }
            }

            //Figure out what scene is active
            ActiveView = views.Find(v => v.IsActive());

            if(ActiveView == null) {
                throw new Exception("Unknown view loaded.");
            }

            //Trigger it's load method
            ActiveView.Load();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        #endregion

        #region Publics

        /// <summary>
        /// Load a view into use. This calls Destroy() on the current one,
        /// if there is one.
        /// </summary>
        /// <typeparam name="T">The type of view to load.</typeparam>
        public void LoadView<T>() where T : GameView {
            //Don't bother loading, it's already loaded.
            if(ActiveView?.GetType() == typeof(T)) {
                return;
            }

            //Find the view we want to load
            GameView nextView = views.Find(v => v.GetType() == typeof(T));

            ActiveView.Destroy();
            ActiveView = nextView;

            //Now we need to being the loading of the scene
            SceneManager.LoadScene(nextView.Name);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Fired off everytime a scene is loaded. We use this to check if
        /// a scene we were waiting on is loaded, and finalize it's load process.
        /// </summary>
        /// <param name="arg0">The loaded scene.</param>
        /// <param name="arg1">How it was loaded.</param>
        /// <exception cref="InvalidOperationException">Thrown when a scene is loaded
        /// but it does not match the one we were expecting.</exception>
        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1) {
            if(ActiveView.Name == arg0.name) {
                ActiveView.Load();
            }
            else {
                throw new InvalidOperationException(string.Format("Incorrect scene was loaded. Expected: {0}, but got: {1}", ActiveView.Name, arg0.name));
            }
        }
        #endregion
    }
}

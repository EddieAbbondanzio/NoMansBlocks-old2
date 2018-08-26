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
        public GameView Current { get; private set; }
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
        #endregion

        #region Module Events
        /// <summary>
        /// Init the module by going out and finding all
        /// views possible.
        /// </summary>
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
            Current = views.Find(v => v.IsActive());

            if(Current == null) {
                throw new Exception("Unknown view loaded.");
            }

            //Trigger it's load method
            Current.Load();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Search for a view using it's type as the search
        /// parameter.
        /// </summary>
        /// <typeparam name="T">The type of view to search for.</typeparam>
        /// <returns>The view found.</returns>
        public T GetView<T>() where T : GameView {
            return views.Find(v => v.GetType() == typeof(T)) as T;
        }

        /// <summary>
        /// Load a view into use. This calls Destroy() on the current one,
        /// if there is one.
        /// </summary>
        /// <typeparam name="T">The type of view to load.</typeparam>
        public void LoadView<T>() where T : GameView {
            Current.Destroy();

            Current = views.Find(v => v.GetType() == typeof(T));
            Current.Load();
        }
        #endregion
    }
}

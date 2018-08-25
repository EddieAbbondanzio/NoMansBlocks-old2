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
                GameView view = Activator.CreateInstance(viewType) as GameView;

                //Only add the view if it supports this engine type
                if(view.Type == Engine.Type) {
                    views.Add(view);
                }
            }

            //Figure out what scene is active
            Current = views.Find(v => v.Name == SceneManager.GetActiveScene().name);

            if(Current == null) {
                throw new Exception("Unknown view loaded.");
            }

            //Trigger it's load method
            Current.Load();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load a view into use. This only loads the view, if it
        /// isn't the currently loaded scene.
        /// </summary>
        /// <param name="name">The name of the view to load.</param>
        public void LoadView(string name) {
            //Remove the old one first
            Current.Destroy();

            //Now we load up the new one.
            Current = views.Find(v => v.Name == name);
            Current.Load();
        }
        #endregion
    }
}

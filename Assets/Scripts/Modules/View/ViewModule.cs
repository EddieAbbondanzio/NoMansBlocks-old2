using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// Module responsible for loading and handling the
    /// various views of the engine.
    /// </summary>
    public class ViewModule : NoMansBlocks.Core.Engine.Module {
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
            List<Type> viewTypes = FindDerivedTypes(typeof(GameView));

            //Now make an instance of each one
            foreach(Type viewType in viewTypes) {
                views.Add(Activator.CreateInstance(viewType) as GameView);
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Load a view into use. This only loads the view, if it
        /// isn't the currently loaded scene.
        /// </summary>
        /// <param name="name">The name of the view to load.</param>
        public void LoadView(string name) {
            //Stop, scene is already loaded.
            if(Current.Name == name) {
                return;
            }

            //Alert the current scene it's being destroyed
            Current.OnDestroy();

            //Now load the new scene
            Current = views.Find(v => v.Name == name);
            if(Current == null) {
                throw new Exception(string.Format("Could not find view: {0}", name));
            }
            else {
                SceneManager.LoadScene(name);
                Current.OnLoad();
            }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Generate a list of every type that implements the 
        /// base type provided.
        /// </summary>
        /// <param name="baseType">The base type to hunt for.</param>
        /// <returns>The lsit of derived types.</returns>
        private List<Type> FindDerivedTypes(Type baseType) {
            return Assembly.GetAssembly(baseType).GetTypes().Where(t => t.IsSubclassOf(baseType)).ToList();
        }
        #endregion
    }
}

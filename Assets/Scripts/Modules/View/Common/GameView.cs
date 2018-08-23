using NoMansBlocks.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// Represents a scene in Unity. Allows for some extra
    /// functionality on them.
    /// </summary>
    public abstract class GameView {
        #region Properties
        /// <summary>
        /// The name of the view, and scene in Unity.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The engine instance that can run this scene.
        /// </summary>
        public abstract EngineType Type { get; }

        /// <summary>
        /// The Unity scene tied to this view.
        /// </summary>
        public Scene Scene { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new gameview. This goes out and attempts to
        /// find the scene for the view.
        /// </summary>
        protected GameView() {
            Scene = SceneManager.GetSceneByName(Name);

            if(Scene == null) {
                throw new Exception(string.Format("Scene not found for view {0}", Name));
            }
        }
        #endregion

        #region View Events
        /// <summary>
        /// This event fires off when the scene is first loaded up.
        /// Use this to find references to game objects etc..
        /// </summary>
        public virtual void OnLoad() {
        }

        /// <summary>
        /// This event fires off when the scene is closing down. Use this
        /// to finalize anything being pulled in from the scene.
        /// </summary>
        public virtual void OnDestroy() {

        }
        #endregion
    }
}

using NoMansBlocks.Logging;
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
    public abstract class Engine : BaseContainer<BaseModule> {
        #region Properties
        /// <summary>
        /// If the engine is a client or server instance.
        /// </summary>
        public abstract EngineType Type { get; }

        /// <summary>
        /// The module used to handle logging to console and
        /// building useful log files.
        /// </summary>
        public LogModule LogModule { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new base instance of the
        /// game engine.
        /// </summary>
        protected Engine() {
            LogModule = new LogModule();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Fires off the init event for every single module
        /// associated with the engine.
        /// </summary>
        public void Init() {
            //See if we can find any modules we need to add to our list.
            base.FindMembers();

            if(Members != null) {
                for(int i = 0; i < Members.Length; i++) {
                    Members[i].OnInit();
                }
            }
        }

        /// <summary>
        /// Called when the engine has initialized. Alert the modules.
        /// </summary>
        public void Start() {
            if (Members != null) {
                for (int i = 0; i < Members.Length; i++) {
                    Members[i].OnStart();
                }
            }
        }

        /// <summary>
        /// Called every tick of the engine. Update every single module
        /// </summary>
        public void Update() {
            if (Members != null) {
                for (int i = 0; i < Members.Length; i++) {
                    Members[i].OnUpdate();
                }
            }
        }

        /// <summary>
        /// Called when the engine is stopping. Alert every module.
        /// </summary>
        public void End() {
            if (Members != null) {
                for (int i = 0; i < Members.Length; i++) {
                    Members[i].OnEnd();
                }
            }
        }
        #endregion
    }
}

using NoMansBlocks.Modules.CommandConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Handles loading and rendering the server menu on screen. This acts
    /// as a mediator to keep things synced up.
    /// </summary>
    public sealed class ServerMenuPresenter : MenuPresenter<ServerMenu> {
        #region Properties
        /// <summary>
        /// The path where the view prefab resides.
        /// </summary>
        protected override string PrefabPath => "Menus/Server/ServerMenu";
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the server menu presenter. This should
        /// only be called by the UI module itself.
        /// </summary>
        /// <param name="uIModule">The parent UI module.</param>
        /// <param name="commandConsole">The command console of the engine.</param>
        public ServerMenuPresenter(IMenuManager uIModule, ICommandConsole commandConsole) : base(uIModule, commandConsole) {
        }
        #endregion

        #region Life Cycle Events
        protected override void OnLoad() {
        }

        protected override void OnDataBind() {

        }

        protected override void OnUnload() {

        }
        #endregion
    }
}

using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// The menu model for the server.
    /// </summary>
    [MenuPresenter(typeof(ServerMenuPresenter))]
    public sealed class ServerMenu : IMenu {
        #region Properties
        /// <summary>
        /// The list of player names currently in the server.
        /// </summary>
        public List<string> PlayerNames { get; set; }

        /// <summary>
        /// The list of log messages 
        /// </summary>
        public TQueue<string> Logs { get; set; }
        #endregion

        #region Properties

        #endregion
    }
}

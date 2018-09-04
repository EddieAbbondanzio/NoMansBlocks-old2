using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Marker interface to indicate that an object is a 
    /// menu model.
    /// </summary>
    public interface IMenu {
        #region Properties
        /// <summary>
        /// The type of presenter that is needed
        /// to run this menu.
        /// </summary>
        Type MenuPresenterType { get; }
        #endregion
    }
}

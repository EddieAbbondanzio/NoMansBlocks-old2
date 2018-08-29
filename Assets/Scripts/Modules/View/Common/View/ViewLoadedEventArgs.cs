using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// Arguments that allow for passing around some
    /// info needed by menus when a view is loaded into
    /// use.
    /// </summary>
    public class ViewLoadedEventArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The transform to attach menu objects to.
        /// </summary>
        public Transform MenuContainer { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new view loaded args using
        /// the transform passed in.
        /// </summary>
        /// <param name="menuContainer">The parent to mate all menus to.</param>
        public ViewLoadedEventArgs(Transform menuContainer) {
            MenuContainer = menuContainer;
        }
        #endregion
    }
}

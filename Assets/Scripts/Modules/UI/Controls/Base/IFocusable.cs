using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// An UI control that can be focused on to direct the users
    /// attention to it or obtain input.
    /// </summary>
    public interface IFocusable {
        #region Publics
        /// <summary>
        /// Focus on the control.
        /// </summary>
        void Focus();

        /// <summary>
        /// Release focus from the control.
        /// </summary>
        void Blur();
        #endregion
    }
}

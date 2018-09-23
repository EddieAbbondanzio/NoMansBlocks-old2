using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// An on screen text label.
    /// </summary>
    public interface ILabel : IControl {
        #region Properties
        /// <summary>
        /// The text being rendered in the label.
        /// </summary>
        string Text { get; set; }
        #endregion

        #region Publics
        /// <summary>
        /// Clear out the contents of the label.
        /// </summary>
        void Clear();
        #endregion
    }
}

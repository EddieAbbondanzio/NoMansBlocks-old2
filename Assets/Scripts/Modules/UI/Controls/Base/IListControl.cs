using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// UI control that handles rendering a collection of data
    /// in some manner.
    /// </summary>
    public interface IListControl<T> : IControl {
        #region Properties
        /// <summary>
        /// The content to databind the control to.
        /// </summary>
        IList<T> DataSource { get; set; }
        #endregion

        #region Publics
        /// <summary>
        /// Databind the view with it's latest data to ensure
        /// everything is kept up to date.
        /// </summary>
        void DataBind();

        /// <summary>
        /// Clear out the datasource and empty out
        /// the list control visually.
        /// </summary>
        void Clear();
        #endregion
    }
}

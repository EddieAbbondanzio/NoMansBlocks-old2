using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// A control that renders a list of strings to the 
    /// screen for the user to see.
    /// </summary>
    public interface ITextList : IControl {
        #region Properties
        /// <summary>
        /// The items to render.
        /// </summary>
        string[] Items { get; set; }
        #endregion

        #region Publics
        /// <summary>
        /// Add a new item to the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void AddItem(string item);

        /// <summary>
        /// Remove all items from the list and databind
        /// it.
        /// </summary>
        void Clear();

        /// <summary>
        /// Update the on screen representation to match
        /// up with the current state of it's items.
        /// </summary>
        void DataBind();

        /// <summary>
        /// Scroll to the very top of the scroll view.
        /// </summary>
        void ScrollToTop();

        /// <summary>
        /// Scroll to the very bottom of the scroll view.
        /// </summary>
        void ScrollToBottom();
        #endregion
    }
}

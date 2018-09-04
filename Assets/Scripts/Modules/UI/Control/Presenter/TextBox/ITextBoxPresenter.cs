﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Presenter {
    /// <summary>
    /// Interface for textbox based controls to derive from.
    /// </summary>
    public interface ITextBoxPresenter : IControlPresenter {
        #region Properties
        /// <summary>
        /// The text inside of the textbox
        /// </summary>
        string Text { get; set; }
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired everytime the value of the textbox is changed.
        /// </summary>
        event EventHandler OnEdit;

        /// <summary>
        /// Fired when the user has finished performing an edit.
        /// </summary>
        event EventHandler OnEndEdit;
        #endregion
    }
}
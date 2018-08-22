using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Represents some kind of string message that came
    /// from the console, chat, or log.
    /// </summary>
    public interface IStatement {
        #region Properties
        /// <summary>
        /// The type of statement.
        /// </summary>
        StatementType StatementType { get; }

        /// <summary>
        /// The time of when the statement was made.
        /// </summary>
        DateTime Time { get; }
        #endregion

        #region Publics
        /// <summary>
        /// Summarize the statemnet in a print friendly
        /// string that can be displayed to the user.
        /// </summary>
        /// <returns>The statement as a string.</returns>
        string Summarize();
        #endregion
    }
}

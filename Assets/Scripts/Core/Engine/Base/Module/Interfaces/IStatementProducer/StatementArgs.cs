using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine
{
    /// <summary>
    /// Arguments that allow for passing around IStatements
    /// through events.
    /// </summary>
    public class StatementArgs : EventArgs {
        #region Properties
        /// <summary>
        /// The statement of the args.
        /// </summary>
        public IStatement Statement { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new statement argument
        /// for passing around a statment.
        /// </summary>
        /// <param name="statement">The new statement.</param>
        public StatementArgs(IStatement statement) {
            Statement = Statement;
        }
        #endregion
    }
}

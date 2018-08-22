using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// For a module that produces statements such as
    /// LogStatements, ChatStatements, etc... This should
    /// only be inherited by modules.
    /// </summary>
    public interface IStatementProducer {
        #region Properties
        /// <summary>
        /// The type of statments this producer creates.
        /// </summary>
        StatementType StatementType { get; }
        #endregion

        #region Events
        /// <summary>
        /// Fired everytime a new statement is created by the producer.
        /// </summary>
        event EventHandler<StatementArgs> OnStatementCreated;
        #endregion
    }
}

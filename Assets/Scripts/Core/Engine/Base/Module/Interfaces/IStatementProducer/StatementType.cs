using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// The type of statement it is.
    /// </summary>
    public enum StatementType : byte {
        Log = 0,
        Chat = 1,
        Command = 2,
    }
}

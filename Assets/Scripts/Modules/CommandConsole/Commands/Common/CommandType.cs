using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Flag to indicate the type of command.
    /// </summary>
    public enum CommandType : byte {
        Connect    = 0,
        Disconnect = 1,
    }
}

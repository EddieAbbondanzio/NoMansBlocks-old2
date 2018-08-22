using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Flag to indicate the general purpose of the message.
    /// </summary>
    public enum NetMessageCategory : byte {
        Meta    = 0,
        Connection = 2,
    }
}

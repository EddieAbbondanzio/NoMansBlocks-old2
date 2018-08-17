using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network.Messages {
    /// <summary>
    /// Flag to indicate the general purpose of the message.
    /// </summary>
    public enum NetMessageCategory : byte {
        Info       = 0,
        Error      = 1,
        Connection = 2,
    }
}

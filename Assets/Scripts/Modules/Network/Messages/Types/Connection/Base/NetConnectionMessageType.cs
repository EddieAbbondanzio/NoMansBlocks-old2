using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Flag to indicate what kind of connection
    /// related message it is.
    /// </summary>
    public enum NetConnectionMessageType : byte {
        Request      = 0,
        Disconnected = 1,
    }
}

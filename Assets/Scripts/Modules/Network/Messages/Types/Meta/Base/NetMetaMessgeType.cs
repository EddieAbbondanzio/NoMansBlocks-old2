using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Message types for messages that derive
    /// from the Meta class base.
    /// </summary>
    public enum NetMetaMessgeType : byte {
        LatencyUpdate = 0,
        Error =         1,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Flag to indicate if we are running a client or 
    /// server instance of the engine.
    /// </summary>
    [Flags]
    public enum GameEngineType {
        Server = 1,
        Client = 2,
        All    = 3
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.UserSystem {
    /// <summary>
    /// The various permission levels supported by the
    /// game engine.
    /// </summary>
    [Flags]
    public enum PermissionLevel {
        None  = 0,
        Guest = 1,
        User  = 2,
        Mod   = 4,
        Admin = 8,
        All   = 15,
    }
}

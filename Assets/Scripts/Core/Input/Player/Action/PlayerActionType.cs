using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input.Player {
    /// <summary>
    /// Enum to represent the possible player actions
    /// that they can perform.
    /// </summary>
    public enum PlayerActionType : byte {
        Jump    = 0,
        StandUp = 1,
        Crouch  = 2,
    }
}

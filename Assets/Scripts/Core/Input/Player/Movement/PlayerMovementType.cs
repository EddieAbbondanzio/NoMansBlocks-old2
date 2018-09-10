using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Input.Player {
    /// <summary>
    /// The various momement directions of the player.
    /// </summary>
    public enum PlayerMovementType : byte {
        Forward    ,
        Backward   ,
        StrafeLeft ,
        StrafeRight,
    }
}

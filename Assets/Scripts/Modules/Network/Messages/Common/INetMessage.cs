using NoMansBlocks.Core.Serialization;
using NoMansBlocks.Core.Serialization.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network.Messages {
    /// <summary>
    /// Interface for every message type to derive from.
    /// </summary>
    public interface INetMessage : IBinarySerializable {
        #region Properties
        /// <summary>
        /// The category of the message.
        /// </summary>
        NetMessageCategory Category { get; }
        #endregion
    }
}

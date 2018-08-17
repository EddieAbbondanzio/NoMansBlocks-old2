using NoMansBlocks.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network {
    /// <summary>
    /// The interface we hand out to everyone when they
    /// want to listen in on network messages. This allows
    /// us to hide the juicy details.
    /// </summary>
    public interface INetMessageListener {
        #region Events
        /// <summary>
        /// Fired when ever an info message is recieved from
        /// over the network.
        /// </summary>
        event EventHandler<NetInfoMessageArgs> OnInfoMessage;

        /// <summary>
        /// Fired when ever an error message is recieved from
        /// over the network.
        /// </summary>
        /// <returns>The incoming error message.</returns>
        event EventHandler<NetErrorMessageArgs> OnErrorMessage;
        #endregion
    }
}

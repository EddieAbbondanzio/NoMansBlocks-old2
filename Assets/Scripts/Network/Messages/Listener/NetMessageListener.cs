using LiteNetLib;
using LiteNetLib.Utils;
using NoMansBlocks.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Network {
    /// <summary>
    /// The actual implementation of the message listener.
    /// This holds full control to firing off the recieved 
    /// message events.
    /// </summary>
    public class NetMessageListener : INetEventListener, INetMessageListener {
        #region Events
        /// <summary>
        /// Fired when ever an info message is recieved from
        /// over the network.
        /// </summary>
        public event EventHandler<NetInfoMessageArgs> OnInfoMessage;

        /// <summary>
        /// Fired whenever an error message comes in from the network.
        /// </summary>
        public event EventHandler<NetErrorMessageArgs> OnErrorMessage;
        #endregion

        #region Publics
        /// <summary>
        /// Don't really give a turd about these things.
        /// </summary>
        /// <param name="peer">The sender of the message.</param>
        /// <param name="latency">Their latency</param>
        public void OnNetworkLatencyUpdate(NetPeer peer, int latency) {
            NetInfoMessage infoMsg = new NetInfoMessage(peer.EndPoint, latency);

            //Fire off the event.
            if(OnInfoMessage != null) {
                OnInfoMessage(this, new NetInfoMessageArgs(infoMsg));
            }
        }

        /// <summary>
        /// An error message came in from over the network.
        /// </summary>
        /// <param name="endPoint">The sender.</param>
        /// <param name="socketErrorCode">The error code of what went wrong.</param>
        public void OnNetworkError(NetEndPoint endPoint, int socketErrorCode) {
            NetErrorMessage errorMsg = new NetErrorMessage(endPoint, socketErrorCode);

            //Fire off the event.
            if(OnErrorMessage != null) {
                OnErrorMessage(this, new NetErrorMessageArgs(errorMsg));
            }
        }


        public void OnPeerConnected(NetPeer peer) {
            //When on server
            //go ahead and create their connection request message
            //this should be processed to add them or reject them

            throw new NotImplementedException();
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo) {
            throw new NotImplementedException();
        }

        public void OnNetworkReceive(NetPeer peer, NetDataReader reader) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// We don't really care about these.
        /// </summary>
        public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType) {
        }
        #endregion
    }
}

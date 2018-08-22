using LiteNetLib;
using LiteNetLib.Utils;
using NoMansBlocks.Modules.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.Network {
    public sealed partial class NetModule {
        /// <summary>
        /// The actual implementation of the message listener.
        /// This holds full control to firing off the recieved 
        /// message events.
        /// </summary>
        public class NetMessageListener : INetEventListener, INetMessageListener {
            #region Events
            /// <summary>
            /// Fired whenever an error message comes in from the network,
            /// or a latency update comes in.
            /// </summary>
            public event EventHandler<NetMetaMessageArgs> OnMetaMessage;

            /// <summary>
            /// Fired whenever a connection related message comes in.
            /// </summary>
            public event EventHandler<NetConnectionMessageArgs> OnConnectionMessage;
            #endregion

            #region Publics
            /// <summary>
            /// Latency updates from peers? Not to useful but we'll
            /// leave them in case the need arises later on.
            /// </summary>
            /// <param name="peer">The sender of the message.</param>
            /// <param name="latency">Their latency</param>
            public void OnNetworkLatencyUpdate(NetPeer peer, int latency) {
                NetLatencyMessage infoMsg = new NetLatencyMessage(peer.EndPoint, latency);

                //Fire off the event.
                if (OnMetaMessage != null) {
                    OnMetaMessage(this, new NetMetaMessageArgs(infoMsg));
                }
            }

            /// <summary>
            /// An error message came in from over the network.
            /// </summary>
            /// <param name="endPoint">The sender.</param>
            /// <param name="socketErrorCode">The error code of what went wrong.</param>
            public void OnNetworkError(NetEndPoint endPoint, int socketErrorCode) {
                NetMetaMessage errorMsg = new NetErrorMessage(endPoint, socketErrorCode);

                //Fire off the event.
                if (OnMetaMessage != null) {
                    OnMetaMessage(this, new NetMetaMessageArgs(errorMsg));
                }
            }

            /// <summary>
            /// Client wishses to connect. Create a connection request
            /// message and send it off via the event.
            /// </summary>
            /// <param name="peer">The client who wishses to connect.</param>
            public void OnPeerConnected(NetPeer peer) {
                NetConnectionRequestMessage requestMsg = new NetConnectionRequestMessage(peer);

                //Fire off the event
                if (OnConnectionMessage != null) {
                    OnConnectionMessage(this, new NetConnectionMessageArgs(requestMsg));
                }
            }

            /// <summary>
            /// Client has disconnected. Create an alert for the server.
            /// </summary>
            /// <param name="peer">The peer who disconnected.</param>
            /// <param name="disconnectInfo">Why they disconnected</param>
            public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo) {
                NetDisconnectedMessage disconnectMsg = new NetDisconnectedMessage(peer, disconnectInfo);

                //Fire off the event
                if (OnConnectionMessage != null) {
                    OnConnectionMessage(this, new NetConnectionMessageArgs(disconnectMsg));
                }
            }

            /// <summary>
            /// Data messsage recieved. These will need to be filtered accordingly.
            /// </summary>
            /// <param name="peer"></param>
            /// <param name="reader"></param>
            public void OnNetworkReceive(NetPeer peer, NetDataReader reader) {
            }

            /// <summary>
            /// We don't really care about these.
            /// </summary>
            public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType) {
            }
            #endregion
        }
    }
}

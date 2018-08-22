using LiteNetLib;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Command to issue a connect to a server from
    /// the client
    /// </summary>
    public sealed class ConnectCommand : Command {
        #region Properties
        /// <summary>
        /// The type of command it is.
        /// </summary>
        public override CommandType CommandType => CommandType.Disconnect;

        /// <summary>
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.All;

        /// <summary>
        /// The endpoint to connect to.
        /// </summary>
        public NetEndPoint EndPoint { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new connect command to connect
        /// to the end point passed in.
        /// </summary>
        /// <param name="endPoint">The endpoint to connect to.</param>
        public ConnectCommand(NetEndPoint endPoint) {
            EndPoint = endPoint;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext"></param>
        public override void Execute(GameEngine executingContext) {
            executingContext.NetModule.Connect(EndPoint);
        }

        /// <summary>
        /// Summarize the command in a print friendly format.
        /// </summary>
        /// <returns>The command in a string form.</returns>
        public override string Summarize() {
            return string.Format("/connect {0}", EndPoint);
        }
        #endregion
    }
}

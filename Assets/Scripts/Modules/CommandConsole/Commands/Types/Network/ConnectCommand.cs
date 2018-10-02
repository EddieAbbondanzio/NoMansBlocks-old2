using LiteNetLib;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.UserSystem;
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
        /// The keyword that comes after the '/'.
        /// </summary>
        public override string Keyword => "connect";

        /// <summary>
        /// The endpoint to connect to.
        /// </summary>
        public NetEndPoint EndPoint { get; set; }
        #endregion

        #region Publics
#pragma warning disable 1998
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="executingContext">The currently running game engine instance.</param>
        public override async Task ExecuteAsync(GameEngine executingContext) {
            executingContext.NetModule.Connect(EndPoint);
        }
#pragma warning restore 1998

        /// <summary>
        /// Process the inputs with the command.
        /// </summary>
        /// <param name="parameters">The list of parameters to process.</param>
        public override void ParseParameters(string[] parameters) {
            EndPoint = Utils.NetUtils.ParseEndPointFromString(parameters[0]);
        }

        /// <summary>
        /// The command as a print friendly string.
        /// </summary>
        /// <returns>The string of the command.</returns>
        public override string ToString() {
            return string.Format("/{0} {1}", Keyword, EndPoint.ToString());
        }
        #endregion
    }
}

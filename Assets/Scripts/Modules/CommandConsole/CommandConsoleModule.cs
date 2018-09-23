using LiteNetLib;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Modules.CommandConsole.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoMansBlocks.Modules.CommandConsole {
    /// <summary>
    /// Module for handling and issue commands to the system.
    /// </summary>
    public sealed class CommandConsoleModule : Module, ICommandConsole {
        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the command
        /// console module.
        /// <paramref name="engine">The engine that owns the module.</paramref>
        /// </summary>
        public CommandConsoleModule(GameEngine engine) : base(engine) {
        }
        #endregion

        #region Publics
        /// <summary>
        /// Parse and process a new command. This attempts to parse user input
        /// so it will produce more log messages to send to the file.
        /// </summary>
        /// <param name="command">The text of the command to parse.</param>
        public void Execute(string command) {
            if(command == null || command[0] != '/') {
                Log.Debug("No command found. Type /help for assistance.");
                return;
            }

            if(Engine == null) {
                throw new Exception("No executing context has been set!");
            }

            Command cmd = ParseCommand(command);

            if(command != null) {
                Execute(cmd);
            }
        }

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void Execute(Command command) {
            if(command == null) {
                return;
            }

            if (Engine == null) {
                throw new Exception("No executing context has been set!");
            }

            Log.Debug(command.Summarize());

            //Dont' care who's executing.
            if(command.RequiredPermissions == PermissionLevel.All) {
                command.Execute(Engine);
            }
            //Check we can execute it, and if we can. Do so.
            else if ((User.Current.PermissionLevel & command.RequiredPermissions) != 0) {
                command.Execute(Engine);
            }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Parse a string to extract a command from it.
        /// </summary>
        /// <param name="input">The command to extract.</param>
        /// <returns>The extracted command.</returns>
        public Command ParseCommand(string input) {
            string[] splitInput = input.Split(' ');
            string commandKey = splitInput[0].TrimStart('/');

            switch (commandKey) {
                case "connect":
                    NetEndPoint connectEndPoint = Utils.NetUtils.ParseEndPointFromString(splitInput[1]);
                    return new ConnectCommand(connectEndPoint);
                case "disconnect":
                    return new DisconnectCommand();
                default:
                    throw new FormatException("Invalid command. Unable to parse.");
            }
        }
        #endregion
    }
}

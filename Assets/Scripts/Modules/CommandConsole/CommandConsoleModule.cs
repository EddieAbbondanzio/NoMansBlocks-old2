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
    public sealed class CommandConsoleModule : Module, IStatementProducer {
        #region Properties
        /// <summary>
        /// Indicator for the IStatementProducer interface to flag what
        /// kind of statements this module produces.
        /// </summary>
        public StatementType StatementType => StatementType.Command;

        /// <summary>
        /// The command parser that extracts commands from strings.
        /// </summary>
        private CommandParser CommandParser { get; }
        #endregion

        #region Events
        /// <summary>
        /// Fired whenever a new log statement is made.
        /// </summary>
        public event EventHandler<StatementArgs> OnStatementCreated;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the command
        /// console module.
        /// <paramref name="engine">The engine that owns the module.</paramref>
        /// </summary>
        public CommandConsoleModule(GameEngine engine) : base(engine) {
            CommandParser = new CommandParser();
        }
        #endregion

        #region Publics
        /// <summary>
        /// Parse and process a new command.
        /// </summary>
        /// <param name="input">The text of the command to parse.</param>
        public void Parse(string input) {
            if(input == null || input[0] != '/') {
                return;
            }

            if(Engine == null) {
                throw new Exception("No executing context has been set!");
            }

            Command command = CommandParser.ParseCommand(input);

            if(command != null) {
                Execute(command);
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

            //Log it
            if(OnStatementCreated != null) {
                OnStatementCreated(this, new StatementArgs(command));
            }

            Log.Debug(command.Summarize());

            //Check we can execute it, and if we can. Do so.
            if((User.Current.PermissionLevel & command.RequiredPermissions) != 0) {
                command.Execute(Engine);
            }
        }
        #endregion
    }
}

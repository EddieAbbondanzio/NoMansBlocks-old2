using LiteNetLib;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.UserSystem;
using NoMansBlocks.Modules.CommandConsole.Commands;
using NoMansBlocks.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;

namespace NoMansBlocks.Modules.CommandConsole {
    /// <summary>
    /// Module for handling and issue commands to the system.
    /// </summary>
    public sealed class CommandConsoleModule : Core.Engine.Module, ICommandConsole {
        #region Members
        /// <summary>
        /// The collection of commands that can be used. The key is their
        /// string keyword.
        /// </summary>
        private Dictionary<string, Type> commands;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the command
        /// console module.
        /// <paramref name="engine">The engine that owns the module.</paramref>
        /// </summary>
        public CommandConsoleModule(GameEngine engine) : base(engine) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Load up the command dictionary for use. This will provide an easy way
        /// to look up commands later on during game play.
        /// </summary>
        public override void OnInit() {
            commands = new Dictionary<string, Type>();
            Type[] commandTypes = ReflectionUtils.GetDerivedTypes(Assembly.GetExecutingAssembly(), typeof(Command)).ToArray();

            //Build the commands dictionary for easy lookup of commands.
            for(int i = 0; i < commandTypes.Length; i++) {
                Command command = Activator.CreateInstance(commandTypes[i]) as Command;

                //Just double check the keyword hasn't already been defined.
                if (commands.ContainsKey(command.Keyword)) {
                    throw new Exception(string.Format("A command with the keyword {0} is already present.", command.Keyword));
                }

                commands.Add(command.Keyword, commandTypes[i]);
            }
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
                Log.Debug("Invalid command. Type /help for assistance.");
                return;
            }

            if(Engine == null) {
                throw new Exception("No executing context has been set!");
            }

            Command cmd = ParseCommand(command);

            if(command != null) {
                Execute(cmd);
            }
            else {
                Log.Debug("No command found. Type /help for assistance.");
            }
        }

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="overridePermissions">If the permissions requirement should be ignored.</param>
        public void Execute(Command command, bool overridePermissions = false) {
            if(command == null) {
                return;
            }

            if (Engine == null) {
                throw new Exception("No executing context has been set!");
            }

            if(overridePermissions || command.HasPermissions(User.Current.PermissionLevel)) {
                Log.Debug(command.ToString());
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
            string keyword = splitInput[0].TrimStart('/');

            //Is the keyword a valid command?
            if (commands.ContainsKey(keyword)) {
                Type commandType = commands[keyword];
                Command command = Activator.CreateInstance(commandType) as Command;

                //Is there some parameters we need to handle?
                if(splitInput.Length > 1) {
                    string[] parameters = new string[splitInput.Length - 1];

                    for(int i = 0; i < parameters.Length; i++) {
                        parameters[i] = splitInput[i + 1];
                    }

                    command.ParseParameters(parameters);
                }

                return command;
            }
            else {
                return null;
            }
        }
        #endregion
    }
}

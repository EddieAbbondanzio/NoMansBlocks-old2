using LiteNetLib;
using NoMansBlocks.Core;
using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.CommandConsole.Commands;
using NoMansBlocks.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;
using NoMansBlocks.Modules.UserSystem;
using System.Threading.Tasks;

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
                    throw new Exception(string.Format("{0} uses keyword {1}. {2} cannot have the same keyword", commands[command.Keyword].GetType(), command.Keyword, command.GetType()));
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
        /// <returns>True if no errors.</returns>
        public async Task<bool> ExecuteAsync(string command) {
            if (command == null || command[0] != '/') {
                Log.Debug("Invalid command. Type /help for assistance.");
                return false;
            }

            if(Engine == null) {
                throw new Exception("No executing context has been set!");
            }

            Command cmd = ParseCommand(command);

            if(command != null) {
                return await ExecuteAsync(cmd);
            }
            else {
                Log.Debug("No command found. Type /help for assistance.");
                return false;
            }
        }

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>True if no errors.</returns>
        public async Task<bool> ExecuteAsync(Command command) {
            if(command == null) {
                return false;
            }

            if (Engine == null) {
                throw new Exception("No executing context has been set!");
            }

            Log.Debug(command.ToString());
            return await command.ExecuteAsync(Engine);
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

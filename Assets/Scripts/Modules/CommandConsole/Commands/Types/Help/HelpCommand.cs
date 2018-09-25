using NoMansBlocks.Core.Engine;
using NoMansBlocks.Core.UserSystem;
using NoMansBlocks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.CommandConsole.Commands {
    /// <summary>
    /// Command that provides a list of commands that can be 
    /// used.
    /// </summary>
    public sealed class HelpCommand : Command {
        #region Statics
        /// <summary>
        /// The generated list of help tips for all
        /// of the commands.
        /// </summary>
        private static List<string> HelpTips;
        #endregion

        #region Properties
        /// <summary>
        /// The keyword that comes after the '/'.
        /// </summary>
        public override string Keyword => "help";

        /// <summary>
        /// Who can invoke the command.
        /// </summary>
        public override PermissionLevel RequiredPermissions => PermissionLevel.All;

        /// <summary>
        /// The help tip to show for the help command.
        /// </summary>
        public override string HelpTip => "Generates a list of all commands and their help tips.";
        #endregion

        #region Publics
        /// <summary>
        /// Print out the list of help tips.
        /// </summary>
        /// <param name="executingContext">The currently executing engine.</param>
        public override void Execute(GameEngine executingContext) {
            if(HelpTips == null) {
                HelpTips = new List<string>();
                List<Type> commandTypes = ReflectionUtils.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(Command));

                for(int i = 0, commandCount = commandTypes.Count; i < commandCount; i++) {
                    Command command = Activator.CreateInstance(commandTypes[i]) as Command;
                    HelpTips.Add(string.Format("{0} {1}", command.Keyword, command.HelpTip));
                }
            }

            for(int h = 0, tipCount = HelpTips.Count; h < tipCount; h++) {
                Log.Debug(HelpTips[h]);
            }
        }
        #endregion
    }
}

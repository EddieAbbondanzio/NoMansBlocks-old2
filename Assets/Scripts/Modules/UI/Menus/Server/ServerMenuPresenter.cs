using NoMansBlocks.Modules.CommandConsole;
using NoMansBlocks.Modules.Logging;
using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Handles loading and rendering the server menu on screen. This acts
    /// as a mediator to keep things synced up.
    /// </summary>
    public sealed class ServerMenuPresenter : MenuPresenter<ServerMenu> {
        #region Properties
        /// <summary>
        /// The path where the view prefab resides.
        /// </summary>
        protected override string PrefabPath => "Menus/Server/ServerMenu";
        #endregion

        #region Members
        /// <summary>
        /// The list control that renders player names to the screen.
        /// </summary>
        private ITextList playerList;

        /// <summary>
        /// The list control that renders logs to the screen.
        /// </summary>
        private ITextList logList;

        /// <summary>
        /// The textbox to pull input in from.
        /// </summary>
        private ITextBox commandTextBox;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the server menu presenter. This should
        /// only be called by the UI module itself.
        /// </summary>
        /// <param name="uIModule">The parent UI module.</param>
        /// <param name="commandConsole">The command console of the engine.</param>
        public ServerMenuPresenter(IMenuManager uIModule, ICommandConsole commandConsole) : base(uIModule, commandConsole) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Subscribe to the logger to listen in on when logs
        /// are being made.
        /// </summary>
        protected override void OnLoad() {
            logList        = GetControl<ITextList>("ConsoleList");
            commandTextBox = GetControl<ITextBox>("CommandTextBox");

            Log.OnLog += Log_OnLog;
            commandTextBox.OnEndEdit += CommandTextBox_OnEndEdit;
        }



        protected override void OnDataBind() {

        }

        /// <summary>
        /// Unsubscribe from any events to prevent member leaks.
        /// </summary>
        protected override void OnUnload() {
            Log.OnLog -= Log_OnLog;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Listen for any logs made by the engine.
        /// </summary>
        /// <param name="sender">The logger.</param>
        /// <param name="e">The log that was made.</param>
        private void Log_OnLog(object sender, LogEventArgs e) {
            logList.AddItem(e.LogStatement.ToStringShort());
            logList.ScrollToBottom();
        }

        /// <summary>
        /// Fired each time the command textbox submits their 
        /// input.
        /// </summary>
        /// <param name="sender">The textbox.</param>
        /// <param name="e">Nothing?.</param>
        private void CommandTextBox_OnEndEdit(object sender, TextBoxEventArgs e) {
            if(e.Action == TextBoxAction.Submit) {
                ExecuteCommand(e.Text);
                commandTextBox.Clear();
                commandTextBox.Focus();
            }
        }
        #endregion
    }
}

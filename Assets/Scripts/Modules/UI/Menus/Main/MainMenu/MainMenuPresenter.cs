using NoMansBlocks.Modules.CommandConsole;
using NoMansBlocks.Modules.CommandConsole.Commands;
using NoMansBlocks.Modules.Config;
using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Presenter that handles loading and syncing up the main menu view
    /// with it's model counterpart.
    /// </summary>
    public sealed class MainMenuPresenter : MenuPresenter<MainMenu> {
        #region Properties
        /// <summary>
        /// The path where the view prefab resides.
        /// </summary>
        protected override string PrefabPath => "Menus/Main/MainMenu";
        #endregion

        #region Members
        /// <summary>
        /// Play button of the menu. This is for when a user wants to connect
        /// to a lobby and start playing.
        /// </summary>
        private ITriggerButton playButton;

        /// <summary>
        /// Settings button of the menu. Contains everything related to brightness,
        /// audio level, and input bindings.
        /// </summary>
        private ITriggerButton settingsButton;

        /// <summary>
        /// Exit button of the menu. The user clicks it when they want to shut 
        /// down and stop playing.
        /// </summary>
        private ITriggerButton exitButton;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the main menu presenter. This should
        /// only be called by the UI Module itself.
        /// </summary>
        /// <param name="uiModule">The parent UI module.</param>
        /// <param name="commandConsole">The command console of the engine</param>
        /// <param name="configContainer">The config container.</param>
        public MainMenuPresenter(IMenuManager uiModule, ICommandConsole commandConsole, IConfigContainer configContainer) : base(uiModule, commandConsole, configContainer) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Allocate resources, or subscribe to events
        /// when the menu is loaded.
        /// </summary>
        protected override void OnLoad() {
            playButton     = GetControl<ITriggerButton>("PlayButton");
            settingsButton = GetControl<ITriggerButton>("SettingsButton");
            exitButton     = GetControl<ITriggerButton>("ExitButton");

            playButton.OnClick     += PlayButton_OnClick;
            settingsButton.OnClick += SettingsButton_OnClick;
            exitButton.OnClick     += ExitButton_OnClick;
        }

        /// <summary>
        /// Free up resources from the menu.
        /// </summary>
        protected override void OnUnload() {
            playButton.OnClick     -= PlayButton_OnClick;
            settingsButton.OnClick -= SettingsButton_OnClick;
            exitButton.OnClick     -= ExitButton_OnClick;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// User clicked the play button. Open up the match finder menu.
        /// </summary>
        /// <param name="sender">The button itself.</param>
        /// <param name="e">Null</param>
        private void PlayButton_OnClick(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// User clicked on the settings button. Open up the settings menu.
        /// </summary>
        /// <param name="sender">The button itself.</param>
        /// <param name="e">Null</param>
        private void SettingsButton_OnClick(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// User clicked on the exit button. Shut. Down. EVERYTHING.
        /// </summary>
        /// <param name="sender">The button itself.</param>
        /// <param name="e">Null</param>
        private void ExitButton_OnClick(object sender, EventArgs e) {
            ExecuteCommandAsync(new StopCommand());
        }
        #endregion
    }
}

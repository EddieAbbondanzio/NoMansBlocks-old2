using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UserSystem {
    /// <summary>
    /// Module responsible for handling user data along with storing
    /// credentials if needed.
    /// </summary>
    public sealed class UserModule : Module {
        #region Properties
        /// <summary>
        /// The login configuration of the user module. This
        /// will always be null on the server.
        /// </summary>
        public LoginConfig LoginConfig { get; private set; }
        #endregion

        #region Members
        /// <summary>
        /// The user service being used to interact with 
        /// the master server.
        /// </summary>
        private IUserService userService;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of a user module.
        /// </summary>
        /// <param name="gameEngine">The running game engine.</param>
        public UserModule(GameEngine gameEngine) : base(gameEngine) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// On the very start of the engine pull in the user 
        /// service so we have a reference back to it.
        /// </summary>
        public override void OnInit() {
            userService = GetService<IUserService>();
            userService.OnUserLogin += UserService_OnUserLogin;

            User.SetUserService(userService);
        }

        /// <summary>
        /// Prepare the user module for use. Attempt to
        /// pull in the login config.
        /// </summary>
        public override void OnStart() {
            if (Engine.Type == GameEngineType.Client) {
                IConfigContainer configContainer = GetModule<ConfigModule>();
                LoginConfig = configContainer.GetConfig<LoginConfig>();
            }
        }

        /// <summary>
        /// When shutting down desubscribe from the login event
        /// to prevent any memory leaks.
        /// </summary>
        public override void OnEnd() {
            userService.OnUserLogin -= UserService_OnUserLogin;
        }

        /// <summary>
        /// A user was logged in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserService_OnUserLogin(object sender, UserEventArgs e) {
            //Does the user want us to save things?
            if (LoginConfig.RememberMe) {
                LoginConfig.Username = e.User.Username;
                LoginConfig.Token = e.User.Login.Token;
            }
        }
        #endregion
    }
}

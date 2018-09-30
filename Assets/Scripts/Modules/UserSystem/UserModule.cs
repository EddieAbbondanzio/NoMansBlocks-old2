using NoMansBlocks.Core.Engine;
using NoMansBlocks.Modules.Config;
using NoMansBlocks.UserSystem;
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
        /// The user service responsible for interfacing
        /// with the user server directly.
        /// </summary>
        public IUserService UserService { get; private set; }

        /// <summary>
        /// The login configuration of the user module. This
        /// will always be null on the server.
        /// </summary>
        public LoginConfig LoginConfig { get; private set; }
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
            UserService = GetService<UserService>();
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
        #endregion
    }
}

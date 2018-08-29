using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.View {
    /// <summary>
    /// THe menu where users can input an address to connect
    /// to. This would be considered the ViewPresenter in MVC
    /// </summary>
    public sealed class ConnectMenu : GameMenu {
        #region Properties
        /// <summary>
        /// The path of where the prefab representing this
        /// menu resides.
        /// </summary>
        protected override string PrefabPath => "Menus/MainView/ConnectMenu";
        #endregion

        #region Members
        /// <summary>
        /// The button users press to attempt to connect
        /// to a server.
        /// </summary>
        private Button connectButton;

        /// <summary>
        /// The buttons users press to return to the
        /// main menu.
        /// </summary>
        private Button cancelButton;
        
        /// <summary>
        /// The textfield containing the server ip address
        /// </summary>
        private InputField addressField;
        #endregion

        #region Event Delegates
        /// <summary>
        /// Fired everytime the user attempts to connect to a
        /// server.
        /// </summary>
        public event EventHandler<ConnectEventArgs> OnConnectAttempt;

        /// <summary>
        /// Fired when the user wants to return to main menu.
        /// </summary>
        public event EventHandler OnCancel;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the connect menu.
        /// </summary>
        /// <param name="view">The view that owns the menu.</param>
        public ConnectMenu(GameView view) : base(view) {
        }
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Called everytime the menu is loaded into the game.
        /// Use this to find resources.
        /// </summary>
        protected override void OnLoad() {
            connectButton = FindChildGameObject("ConnectButton").GetComponent<Button>();
            cancelButton  = FindChildGameObject("CancelButton").GetComponent<Button>();
            addressField  = FindChildGameObject("AddressField").GetComponent<InputField>();
        }

        /// <summary>
        /// Prevent any memory leaks.
        /// </summary>
        protected override void OnDestroy() {
            connectButton.onClick.RemoveListener(OnConnectClicked);
            cancelButton.onClick.RemoveListener(OnCancelClicked);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// User wants to attempt to connect to the server address
        /// passed in.
        /// </summary>
        private void OnConnectClicked() {
            string ipAddress = addressField.text;

            NetEndPoint endPoint = NoMansBlocks.Utils.NetUtils.ParseEndPointFromString(ipAddress);

            if(endPoint != null && OnConnectAttempt != null) {
                OnConnectAttempt(this, new ConnectEventArgs(endPoint));
            }
        }

        /// <summary>
        /// User wants to return to the main menu.
        /// </summary>
        private void OnCancelClicked() {
            if(OnCancel != null) {
                OnCancel(this, null);
            }
        }
        #endregion
    }
}

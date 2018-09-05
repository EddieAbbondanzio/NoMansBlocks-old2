using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Modules.UI.Menus {
    /// <summary>
    /// Attribute to indicate what kind of menu presenter to
    /// use on a menu.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false)]
    public sealed class MenuPresenterAttribute : Attribute {
        #region Properties
        /// <summary>
        /// The type of menu presenter to use on the menu model.
        /// </summary>
        public Type Type { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the menu presenter attribute.
        /// This allows for passing in the type without having to specify 
        /// a named parameter on the attribute.
        /// </summary>
        /// <param name="menuPresenterType">The type of menu presenter to use on the menu model.</param>
        public MenuPresenterAttribute(Type menuPresenterType) {
            Type = menuPresenterType;
        }
        #endregion
    }
}

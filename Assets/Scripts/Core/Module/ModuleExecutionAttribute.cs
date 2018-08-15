using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Allows for customizing how modules are executed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ModuleExecutionAttribute : Attribute {
        #region Properties
        /// <summary>
        /// What position in the execution array this module
        /// should be ran at.
        /// </summary>
        public byte Index { get; set; }
        #endregion
    }
}

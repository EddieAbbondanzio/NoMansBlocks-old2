using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Allows for customizing how modules are executed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ModuleExecutionAttribute : Attribute {
        #region Properties
        /// <summary>
        /// What position in the execution array this module
        /// should be ran at.
        /// </summary>
        public byte ExecutionIndex { get; set; } = byte.MaxValue;

        /// <summary>
        /// Disable the Update method of a module from being
        /// called.
        /// </summary>
        public bool DisableUpdate { get; set; } = false;

        /// <summary>
        /// If the module is enabled for use.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// If the module should be ran in debug mode.
        /// </summary>
        public bool Debug { get; set; } = false;
        #endregion
    }
}

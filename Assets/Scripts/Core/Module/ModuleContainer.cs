using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Base class to derive objects that are comprised of
    /// multiple modules. This will go out and find all the modules
    /// attached to the class as properties.
    /// </summary>
    public abstract class ModuleContainer {
        #region Properties
        /// <summary>
        /// The items stored in the container
        /// </summary>
        public Module[] Modules { get; private set; }
        #endregion

        #region Publics
        /// <summary>
        /// Find the members associated with the container
        /// and add them to the members array.
        /// </summary>
        public void FindMembers() {
            PropertyInfo[] memberProperties = this.GetType().GetProperties().Where(p => p.PropertyType.IsSubclassOf(typeof(Module)) || p.PropertyType == typeof(Module)).ToArray();
            Modules = new Module[memberProperties.Length];

            for (int i = 0; i < memberProperties.Length; i++) {
                Modules[i] = memberProperties[i].GetValue(this) as Module;

                //If a module has a custom execution index, pull it in.
                ModuleExecutionAttribute executionAttribute = memberProperties[i].GetCustomAttribute<ModuleExecutionAttribute>();
                if(executionAttribute != null) {
                    Modules[i].ExecutionIndex = executionAttribute.Index;
                }
            }

            //Lastly we order by execution index
            Modules = Modules.OrderBy(m => m.ExecutionIndex).ToArray();
        }
        #endregion
    }
}

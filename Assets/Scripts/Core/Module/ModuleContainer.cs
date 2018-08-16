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
        public void FindModules() {
            PropertyInfo[] memberProperties = this.GetType().GetProperties().Where(p => p.PropertyType.IsSubclassOf(typeof(Module)) || p.PropertyType == typeof(Module)).ToArray();
            Modules = new Module[memberProperties.Length];

            for (int i = 0; i < memberProperties.Length; i++) {
                Modules[i] = memberProperties[i].GetValue(this) as Module;
                Modules[i].Container = this;

                //If a module has a custom execution index, pull it in.
                ModuleExecutionAttribute executionAttribute = memberProperties[i].GetCustomAttribute<ModuleExecutionAttribute>();
                if(executionAttribute != null) {
                    //Set the execution index, and disable update here.
                    Modules[i].ExecutionIndex = executionAttribute.ExecutionIndex;
                    Modules[i].Enabled        = executionAttribute.Enabled;
                    Modules[i].DisableUpdate  = executionAttribute.DisableUpdate;
                }
            }

            //Lastly we order by execution index
            Modules = Modules.OrderBy(m => m.ExecutionIndex).ToArray();
        }

        /// <summary>
        /// Retrieve a module via it's type.
        /// </summary>
        /// <typeparam name="T">The type (or base type) of module to look for.</typeparam>
        /// <returns>The module found (if any).</returns>
        public T GetModule<T>() where T : Module {
            for(int i = 0; i < Modules.Length; i++) {
                Type moduleType = Modules[i].GetType();

                if(moduleType == typeof(T) || moduleType.IsSubclassOf(typeof(T))) {
                    return Modules[i] as T;
                }
            }

            return null;
        }
        #endregion

        #region 
        /// <summary>
        /// Initialize the modules associated with the container
        /// by calling the .Init() method on each one.
        /// </summary>
        protected void InitModules() {
            if (Modules != null) {
                for (int i = 0; i < Modules.Length; i++) {
                    if (Modules[i].Enabled) {
                        Modules[i].OnInit();
                    }
                }
            }
        }

        /// <summary>
        /// Start the modules associated with the container
        /// by calling the .Start() method on each one.
        /// </summary>
        protected void StartModules() {
            if (Modules != null) {
                for (int i = 0; i < Modules.Length; i++) {
                    if (Modules[i].Enabled) {
                        Modules[i].OnStart();
                    }
                }
            }
        }

        /// <summary>
        /// Update the modules associated with the container
        /// by calling the .Update() method on each one. This skips
        /// any modules that have their update disabled.
        /// </summary>
        protected void UpdateModules() {
            if (Modules != null) {
                for (int i = 0; i < Modules.Length; i++) {
                    if (Modules[i].Enabled && !Modules[i].DisableUpdate) {
                        Modules[i].OnUpdate();
                    }
                }
            }
        }

        /// <summary>
        /// End the modules associated with the container
        /// by calling the .End() method on each one.
        /// </summary>
        protected void EndModules() {
            if (Modules != null) {
                for (int i = 0; i < Modules.Length; i++) {
                    if (Modules[i].Enabled) {
                        Modules[i].OnEnd();
                    }
                }
            }
        }
        #endregion
    }
}

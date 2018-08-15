using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// A container is an object that can hold a collection of 
    /// smaller objects within itself.
    /// </summary>
    public abstract class BaseContainer<T> where T : class {
        #region Properties
        /// <summary>
        /// The items stored in the container
        /// </summary>
        public T[] Members { get; private set; }
        #endregion

        #region Publics
        /// <summary>
        /// Find the members associated with the container
        /// and add them to the members array.
        /// </summary>
        public void FindMembers() {
            PropertyInfo[] memberProperties = this.GetType().GetProperties().Where(p => p.PropertyType.IsSubclassOf(typeof(T))).ToArray();
            Members = new T[memberProperties.Length];

            for(int i = 0; i < memberProperties.Length; i++) {
                Members[i] = memberProperties[i].GetValue(this) as T;
            }
        }
        #endregion
    }
}

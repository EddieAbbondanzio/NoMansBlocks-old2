using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Utils {
    /// <summary>
    /// Interface for a object pool to derive from. An object
    /// pool acts a storage place to keep inactive gameobjects 
    /// in memory to prevent having to instantiate and destroy
    /// gameobject's during game play.
    /// </summary>
    /// <typeparam name="T">The type of object it returns. This
    /// will be the component it returns the object as.</typeparam>
    public interface IObjectPool<T> {
        #region Publics
        /// <summary>
        /// Retrieve an instance from the object pool. This will get
        /// it up and running and ready to go.
        /// </summary>
        /// <returns>The object that was pulled from the pool.</returns>
        T GetInstance();

        /// <summary>
        /// Return an instance back to the object pool. This 
        /// resets the object back to an inactive state but 
        /// keeps it in memory.
        /// </summary>
        /// <param name="instance">The instance being returned.</param>
        void ReturnInstance(T instance);
        #endregion
    }
}

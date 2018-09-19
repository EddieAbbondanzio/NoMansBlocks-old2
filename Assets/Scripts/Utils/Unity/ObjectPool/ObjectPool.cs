using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Utils.Unity {
    /// <summary>
    /// An object pool for storing inactive objects in memory instead
    /// of needing to constantly instantiate and destroy game objects
    /// during runtime.
    /// </summary>
    public sealed class ObjectPool : MonoBehaviour {
        #region Unity Fields
        /// <summary>
        /// The minimum number of objects to keep in the pool at
        /// any time.
        /// </summary>
        public int LowerBound;
        
        /// <summary>
        /// The maximum number of objects to keep in the pool at
        /// any time. This does not apply to active objects.
        /// </summary>
        public int UpperBound;

        /// <summary>
        /// The prefab to use to instantiate objects with.
        /// </summary>
        public GameObject Prefab;
        #endregion

        #region Publics
        public GameObject GetObject() {
            throw new NotImplementedException();
        }

        public void ReturnObject(GameObject obj) {
            throw new NotImplementedException();
        }
        #endregion
    }
}

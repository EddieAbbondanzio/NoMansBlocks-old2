using NoMansBlocks.Modules.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Utils {
    /// <summary>
    /// An object pool for storing instances of spare game
    /// objects during run time. It is highly recommended that only
    /// interface references are given out.
    /// </summary>
    [ExecuteInEditMode]
    public abstract class ObjectPool<T> : MonoBehaviour, IObjectPool<T> {
        #region Unity Fields
        /// <summary>
        /// The target number of objects to maintain in the pool
        /// at any time. This can be exceeded when demanded.
        /// </summary>
        [SerializeField]
        [Header("Settings")]
        [Tooltip("The ideal size of the pool. During extreme load the active count can exceed this, but it will have to instantiate new objects.")]
        private int capacity;

        /// <summary>
        /// The container parent to place all the instances under.
        /// </summary>
        [Tooltip("The parent object to attach all instances under.")]
        public Transform Container;

        /// <summary>
        /// The prefab object to instantiate and hold in the pool.
        /// </summary>
        [Tooltip("The prefab object that will be cloned and managed in the pool")]
        public GameObject Prefab;
        #endregion

        #region Properties
        /// <summary>
        /// The ideal size of the pool.
        /// </summary>
        public int Capacity { get { return capacity; } set { capacity = value; } }
        #endregion

        #region Members
        /// <summary>
        /// The current size of the object pool.
        /// </summary>
        [Header("State")]
        [ReadOnlyField]
        [SerializeField]
        [Tooltip("The total number of instances in the pool. This counts both active, and inactive instances.")]
        private int currentCount;

        /// <summary>
        /// The current number of active objects in
        /// the pool.
        /// </summary>
        [ReadOnlyField]
        [SerializeField]
        [Tooltip("The current number of instances that are active, and being used by others.")]
        private int activeCount;

        /// <summary>
        /// The pooled instances being managed. These are the objects waiting
        /// to be used.
        /// </summary>
        private Queue<GameObject> inactiveInstances;
        #endregion

        #region Life Cycle Events
        /// <summary>
        /// Ensure all the user input is okay.
        /// </summary>
        private void OnValidate() {
            if(Capacity < 1) {
                Capacity = 1;
                Debug.Log("Capacity cannot be less than 1 for the Object Pool");
            }
        }

        /// <summary>
        /// When the script first starts up, go out and find all children
        /// of the pool container. If we find any, pull them in!
        /// </summary>
        private void Awake() {
            if (Container != null && Prefab != null) {
                InitializePool();
            }
            else if (Application.isPlaying) {
                throw new Exception("Object pool has been incorrectly set up.");
            }
        }

        /// <summary>
        /// Manage the pool. Need to know when we are simply 
        /// running in the editor, vs during game play.
        /// </summary>
        private void Update() {
            if (Container == null || Prefab == null) {
                return;
            }

            if (!Application.isPlaying) {
                //Unity doesn't call Awake() when code is recompiled,
                //so check if we need to re-init.
                if (inactiveInstances == null) {
                    InitializePool();
                }

                if (Capacity < currentCount) {
                    int removeCount = currentCount - Capacity;

                    for (int i = 0; i < removeCount; i++) {
                        GameObject instance = inactiveInstances.Dequeue();
                        DestroyImmediate(instance);
                        currentCount--;
                    }
                }
                else if (Capacity > currentCount) {
                    int addCount = Capacity - currentCount;

                    for (int i = 0; i < addCount; i++) {
                        GameObject instance = Instantiate(Prefab, Container);
                        instance.SetActive(false);
                        inactiveInstances.Enqueue(instance);
                        currentCount++;
                    }
                }
            }
            else {
                //Any inactives we no longer need?
                while(Capacity < currentCount && inactiveInstances.Count > 0 && !inactiveInstances.Peek().activeSelf) {
                    Destroy(inactiveInstances.Dequeue());
                    currentCount--;
                }
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Get a new instance from the pool.
        /// </summary>
        /// <returns>The pooled instance to use.</returns>
        public T GetInstance() {
            if (inactiveInstances.Count > 0) {
                GameObject instance = inactiveInstances.Dequeue();
                instance.SetActive(true);
                activeCount++;

                OnGetInstance(instance);
                return instance.GetComponent<T>();
            }
            else {
                GameObject instance = Instantiate(Prefab, Container);
                return instance.GetComponent<T>();
            }
        }

        /// <summary>
        /// Get a new instance from the pool.
        /// </summary>
        /// <param name="instance"></param>
        public void ReturnInstance(T instance) {
            MonoBehaviour monoBehaviour = instance as MonoBehaviour;

            if(monoBehaviour == null) {
                throw new ArgumentException("A non MonoBehaviour object was passed back. Why?");
            }

            OnReturnInstance(monoBehaviour.gameObject);

            //Reset it back to defaults, and stack it.
            monoBehaviour.transform.parent = Container;
            monoBehaviour.gameObject.SetActive(false);

            inactiveInstances.Enqueue(monoBehaviour.gameObject);
            activeCount--;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Helper for derived classes to implement when they need to do
        /// something to the object before it gets handed out.
        /// </summary>
        /// <param name="instance">The instance being set active.</param>
        protected virtual void OnGetInstance(GameObject instance) {

        }

        /// <summary>
        /// Helper for derived classes to implement when they need to do something
        /// to the object before it gets returned to the pool.
        /// </summary>
        /// <param name="instance">The instance being returned.</param>
        protected virtual void OnReturnInstance(GameObject instance) {

        }

        /// <summary>
        /// Get the pool ready for use.
        /// </summary>
        private void InitializePool() {
            inactiveInstances = new Queue<GameObject>();

            foreach (Transform child in Container) {
                GameObject instance = child.gameObject;

                inactiveInstances.Enqueue(instance);

                if (instance.activeSelf) {
                    instance.SetActive(false);
                }
            }

            currentCount = inactiveInstances.Count;
        }
        #endregion
    }
}

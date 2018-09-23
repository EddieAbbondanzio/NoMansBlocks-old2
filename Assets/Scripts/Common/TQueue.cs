using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks {
    /// <summary>
    /// A thread safe variant of the standard queue.
    /// </summary>
    /// <typeparam name="T">The type of objects it holds.</typeparam>
    [DebuggerDisplay("Count = {queue.Count}")]
    public class TQueue<T> {
        #region Properties
        /// <summary>
        /// The number of elements currently in the queue.
        /// </summary>
        public int Count => queue.Count;

        /// <summary>
        /// The maximum number of items allowed in the queue
        /// at any time. -1 if infinite.
        /// </summary>
        public int Capacity { get; }
        #endregion

        #region Members
        /// <summary>
        /// The underlying queue.
        /// </summary>
        private Queue<T> queue;

        /// <summary>
        /// The semaphore lock object.
        /// </summary>
        private readonly object lockObj;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new empty queue.
        /// </summary>
        public TQueue() {
            queue    = new Queue<T>();
            lockObj  = new object();
            Capacity = -1;
        }

        /// <summary>
        /// Create a new queue from an existing collection.
        /// </summary>
        /// <param name="collection">The collecton to populate the queue with.</param>
        /// <param name="capacity">The maximum number of items allowed in the queue.</param>
        public TQueue(IEnumerable<T> collection, int capacity = -1) {
            queue    = new Queue<T>(collection);
            lockObj  = new object();
            Capacity = capacity;
        }

        /// <summary>
        /// Create a new fixed sized queue.
        /// </summary>
        /// <param name="capacity">The maximum number of items in the queue
        /// at any time.</param>
        public TQueue(int capacity) {
            queue    = new Queue<T>();
            lockObj  = new object();
            Capacity = capacity;
        }
        #endregion

        #region Publics
        /// <summary>
        /// Empty out the queue.
        /// </summary>
        public void Clear() {
            lock (lockObj) {
                queue.Clear();
            }
        }

        /// <summary>
        /// Checks if the queue contains a specific item.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns>True if the queue contains the item
        /// passed in.</returns>
        public bool Contains(T item) {
            lock (lockObj) {
                return queue.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex) {
            lock (lockObj) {
                queue.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// Dequeue the next element from the front of the queue.
        /// </summary>
        /// <returns>The next dequeued element.</returns>
        public T Dequeue() {
            lock (lockObj) {
                return queue.Dequeue();
            }
        }

        /// <summary>
        /// Enqueue an element to the back of the queue.
        /// </summary>
        /// <param name="item">The item to add to the end.</param>
        public void Enqueue(T item) {
            lock (lockObj) {
                queue.Enqueue(item);

                //Trim the fat
                if(Capacity > 0 && queue.Count > Capacity) {
                    queue.Dequeue();
                }
            }
        }

        /// <summary>
        /// Peek at the next element that will be returned when
        /// .dequeue() is called.
        /// </summary>
        /// <returns>The next element without incrementing the pointer.</returns>
        public T Peek() {
            lock (lockObj) {
                return queue.Peek();
            }
        }

        /// <summary>
        /// Convert the contents of the queue into an array.
        /// </summary>
        /// <returns>The queue as an array.</returns>
        public T[] ToArray() {
            lock (lockObj) {
                return queue.ToArray();
            }
        }
        #endregion
    }
}

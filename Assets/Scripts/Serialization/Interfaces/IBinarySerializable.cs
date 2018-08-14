using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Serialization {
    /// <summary>
    /// Interface to indicate that an object can be
    /// serialized into a byte[] array. This interface requires
    /// derived objects to implement a constructor that
    /// accepts a single parameter of type byte[]. Failure to do so
    /// will cause runtime errors.
    /// </summary>
    public interface IBinarySerializable {
        #region Publics
        /// <summary>
        /// Serialize the object into a byte array that can be
        /// stored to file or sent over the network.
        /// </summary>
        /// <returns>The serialized object.</returns>
        byte[] Serialize();
        #endregion
    }
}

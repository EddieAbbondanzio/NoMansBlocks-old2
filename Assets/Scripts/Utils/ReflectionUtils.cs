using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Utils {
    /// <summary>
    /// Utility methods for reflection based tasks.
    /// </summary>
    public static class ReflectionUtils {
        /// <summary>
        /// Generate a list of derived types that all implement
        /// the passed in based type.
        /// </summary>
        /// <param name="assembly">The assembly that holds the type.</param>
        /// <param name="baseType">The base type to hunt for.</param>
        /// <returns>The list of types that implement the base.</returns>
        public static List<Type> FindDerivedTypes(Assembly assembly, Type baseType) {
            return assembly.GetTypes().Where(t => baseType.IsAssignableFrom(t) && t != baseType).ToList();
        }
    }
}

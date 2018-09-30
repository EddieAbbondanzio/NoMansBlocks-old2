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
        /// Checks to see if the derived type is derived
        /// from the base type. This provides a common way to
        /// work with abstract classes, regular classes, or interfaces.
        /// </summary>
        /// <param name="baseType">The base type.</param>
        /// <param name="derivedType">The derived type to check.</param>
        /// <returns>True if the derived type inherits, or implements the baseType.</returns>
        public static bool IsSubType(Type baseType, Type derivedType) {
            return derivedType.IsAssignableFrom(baseType);
        } 


        /// <summary>
        /// Generate a list of derived types that all implement
        /// the passed in based type.
        /// </summary>
        /// <param name="assembly">The assembly that holds the type.</param>
        /// <param name="baseType">The base type to hunt for.</param>
        /// <returns>The list of types that implement the base.</returns>
        public static IEnumerable<Type> GetDerivedTypes(Assembly assembly, Type baseType) {
            return assembly.GetTypes().Where(t => baseType.IsAssignableFrom(t) && t != baseType);
        }

        /// <summary>
        /// Get all properties of the specific type passed in on the 
        /// desired object type. This will include interface implementations
        /// or derived types.
        /// </summary>
        /// <param name="objectType">The parent object.</param>
        /// <param name="propertyType">The type of properties to look for.</param>
        /// <returns>The list of matching properties.</returns>
        public static IEnumerable<PropertyInfo> GetPropertiesOfType(Type objectType, Type propertyType) {
            return objectType.GetProperties().Where(p => propertyType.IsAssignableFrom(p.PropertyType) || p.PropertyType == propertyType);
        }
    }
}

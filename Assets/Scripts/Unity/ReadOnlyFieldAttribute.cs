using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Attribute to indicate that a field should be serialized in the
/// editor, but as a read only.
/// </summary>
public sealed class ReadOnlyFieldAttribute : Attribute {
}

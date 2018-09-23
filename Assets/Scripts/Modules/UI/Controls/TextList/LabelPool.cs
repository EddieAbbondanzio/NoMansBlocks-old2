using NoMansBlocks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace NoMansBlocks.Modules.UI.Controls {
    /// <summary>
    /// Object pool for managing Unity UI Text objects.
    /// </summary>
    public sealed class LabelPool : ObjectPool<ILabel> {
        /// <summary>
        /// When returning text back to the pool, ensure we clear it out.
        /// </summary>
        /// <param name="instance">The instance being returned.</param>
        protected override void OnReturnInstance(GameObject instance) {
            ILabel label = instance.GetComponent<ILabel>();
            label.Clear();
        }
    }
}

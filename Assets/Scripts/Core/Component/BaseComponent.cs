using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core {
    /// <summary>
    /// Base class to derive components from. This provides functionality to
    /// handle updating, and listening to engine life cycle events.
    /// </summary>
    public abstract class BaseComponent : IEngineCycleListener {
        #region Publics
        public virtual void OnInit() {
        }

        public virtual void OnUpdate() {
        }

        public virtual void OnStart() {
        }

        public virtual void OnEnd() {
        }
        #endregion
    }
}

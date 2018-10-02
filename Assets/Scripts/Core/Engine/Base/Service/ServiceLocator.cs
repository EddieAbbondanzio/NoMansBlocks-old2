using NoMansBlocks.Modules.Input;
using NoMansBlocks.Modules.Logging;
using NoMansBlocks.Modules.UserSystem;
using NoMansBlocks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoMansBlocks.Core.Engine {
    /// <summary>
    /// Interface for a service locater that handles
    /// locating all dependencies for the game engine.
    /// </summary>
    public abstract class ServiceLocator {
        #region Properties
        /// <summary>
        /// The logger to use for writing to the log
        /// file or console.
        /// </summary>
        public ILogger Logger { get; protected set; }

        /// <summary>
        /// The input poller for checking input state with.
        /// </summary>
        public IInputPoller InputPoller { get; protected set; }

        /// <summary>
        /// The user service for contacting the master server with.
        /// </summary>
        public IUserService UserService { get; protected set; }
        #endregion

        #region Members
        /// <summary>
        /// The underlying cache of services 
        /// </summary>
        private IService[] services;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create a new instance of the service locator. This will
        /// hook up all of the services for use.
        /// </summary>
        protected ServiceLocator() {
            InitServices();

            PropertyInfo[] memberProperties = ReflectionUtils.GetPropertiesOfType(GetType(), typeof(IService)).ToArray();
            services = new IService[memberProperties.Length];

            for (int i = 0; i < memberProperties.Length; i++) {
                services[i] = memberProperties[i].GetValue(this) as IService;
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Get a service of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of service to retrieve.</typeparam>
        /// <returns>The service found. If any.</returns>
        public T GetService<T>() where T : class, IService {
            Type desiredType = typeof(T);

            for (int i = 0; i < services.Length; i++) {
                Type serviceType = services[i].GetType();

                if (serviceType == desiredType || ReflectionUtils.IsSubType(serviceType, desiredType)) {
                    return services[i] as T;
                }
            }

            return null;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Initialize all the services on the locator for use.
        /// </summary>
        protected abstract void InitServices();
        #endregion
    }
}

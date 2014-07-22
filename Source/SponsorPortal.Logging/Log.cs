using System;
using System.Linq;

namespace SponsorPortal.Logging
{
    public class Log
    {
        private static ILogFactory[] _logFactories;

        /// <summary>
        /// Initializes the logAction factory.
        /// </summary>
        /// <param name="logFactories">The logAction factory.</param>
        public static void InitializeLogFactory(params ILogFactory[] logFactories)
        {
            _logFactories = logFactories;
        }

        /// <summary>
        /// Returns a ILog implementation for the specified object
        /// </summary>
        /// <param name="itemThatRequiresLoggingServices">The item that requires logging services.</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public static void Msg(object itemThatRequiresLoggingServices, Action<ILog> logAction)
        {
            Msg(itemThatRequiresLoggingServices.GetType(), logAction);
        }

        /// <summary>
        /// Returns a ILog implementation for the specified type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public static void Msg(Type type, Action<ILog> logAction)
        {
            if (_logFactories == null || !_logFactories.Any())
            {
                // When no custom logger is configured, use the debug output
                _logFactories = new ILogFactory[] { new DebugLogFactory() };
            }

            foreach (var factory in _logFactories)
                logAction(factory.CreateFor(type));
        }
    }
}

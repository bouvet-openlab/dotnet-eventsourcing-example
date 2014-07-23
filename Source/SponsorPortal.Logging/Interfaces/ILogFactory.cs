using System;

namespace SponsorPortal.Logging.Interfaces
{
    /// <summary>
    /// Interface to be implemented by custom loggers
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// Returns a ILog implementation for the implemented log factory
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        ILog CreateFor(Type type);
    }
}

using System;
using log4net;
using log4net.Config;

namespace SponsorPortal.Logging
{
    /// <summary>
    /// Log4Net implementation
    /// </summary>
    public class Log4NetLogFactory : ILogFactory
    {
        public Log4NetLogFactory()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Returns a ILog implementation for the implemented log factory
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public ILog CreateFor(Type type)
        {
            return new Log4NetLogger(type);
        }

        /// <summary>
        /// The concrete log4net logger
        /// </summary>
        private class Log4NetLogger : ILog
        {
            private readonly log4net.ILog _logger;

            /// <summary>
            /// Initializes a new instance of the <see cref="Log4NetLogger"/> class.
            /// </summary>
            /// <param name="type">The type.</param>
            public Log4NetLogger(Type type)
            {
                _logger = LogManager.GetLogger(type);
            }

            /// <summary>
            /// Writes an informational message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Info(string message)
            {
                _logger.Info(message);
            }

            /// <summary>
            /// Writes an informational message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Info(string message, params string[] args)
            {
                _logger.InfoFormat(message, args);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Warning(string message)
            {
                _logger.Warn(message);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Warning(string message, params string[] args)
            {
                _logger.WarnFormat(message, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Error(string message)
            {
                _logger.Error(message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Error(string message, params string[] args)
            {
                _logger.ErrorFormat(message, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="ex">The exeption.</param>
            /// <param name="args">The args.</param>
            public void Error(string message, Exception ex, params string[] args)
            {
                _logger.Error(string.Format(message, args), ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="ex">The exeption.</param>
            public void Error(string message, Exception ex)
            {
                _logger.Error(message, ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exeption.</param>
            public void Error(Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}

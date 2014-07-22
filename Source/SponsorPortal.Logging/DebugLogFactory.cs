using System;
using System.Diagnostics;

namespace SponsorPortal.Logging
{
    /// <summary>
    /// Logger implementation logging to the debug output window
    /// </summary>
    public class DebugLogFactory : ILogFactory
    {
        #region ILogFactory Members

        /// <summary>
        /// Returns a ILog implementation for the implemented log factory
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public ILog CreateFor(Type type)
        {
            return new DebugLogger();
        }

        #endregion

        #region Nested type: DebugLogger

        private class DebugLogger : ILog
        {
            #region ILog Members

            /// <summary>
            /// Writes an informational message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Info(string message)
            {
                Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Warning(string message)
            {
                Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Error(string message)
            {
                Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes an informational message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Info(string message, params string[] args)
            {
                Debug.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Warning(string message, params string[] args)
            {
                Debug.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Error(string message, params string[] args)
            {
                Debug.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="ex">The exeption.</param>
            /// <param name="args">The args.</param>
            public void Error(string message, Exception ex, params string[] args)
            {
                Debug.WriteLine(string.Format(message, args) + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="ex">The exeption.</param>
            public void Error(string message, Exception ex)
            {
                Debug.WriteLine(message + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exeption.</param>
            public void Error(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            #endregion
        }

        #endregion
    }
}

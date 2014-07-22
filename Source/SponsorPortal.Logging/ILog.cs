using System;

namespace SponsorPortal.Logging
{
    /// <summary>
    /// Interface to be implemented by concrete loggers
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Writes an informational message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        /// <summary>
        /// Writes a warning message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        void Warning(string message);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        /// Writes an informational message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The args.</param>
        void Info(string message, params string[] args);

        /// <summary>
        /// Writes a warning message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The args.</param>
        void Warning(string message, params string[] args);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The args.</param>
        void Error(string message, params string[] args);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The exeption.</param>
        /// <param name="args">The args.</param>
        void Error(string message, Exception ex, params string[] args);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The exeption.</param>
        void Error(string message, Exception ex);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="ex">The exeption.</param>
        void Error(Exception ex);
    }
}

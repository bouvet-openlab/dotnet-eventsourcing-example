using System;

namespace SponsorPortal.Logging
{
    public class ConsoleLogFactory : ILogFactory
    {
        public ILog CreateFor(Type type)
        {
            return new ConsoleLogger();
        }

        private class ConsoleLogger : ILog
        {
            /// <summary>
            /// Writes an informational message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Info(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Warning(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            public void Error(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes an informational message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Info(string message, params string[] args)
            {
                Console.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Warning(string message, params string[] args)
            {
                Console.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="args">The args.</param>
            public void Error(string message, params string[] args)
            {
                Console.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="ex">The exeption.</param>
            /// <param name="args">The args.</param>
            public void Error(string message, Exception ex, params string[] args)
            {
                Console.WriteLine(string.Format(message, args) + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="ex">The exeption.</param>
            public void Error(string message, Exception ex)
            {
                Console.WriteLine(message + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exeption.</param>
            public void Error(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

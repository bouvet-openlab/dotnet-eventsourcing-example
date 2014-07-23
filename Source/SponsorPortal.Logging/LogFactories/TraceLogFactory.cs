using System;
using System.Diagnostics;
using SponsorPortal.Logging.Interfaces;

namespace SponsorPortal.Logging.LogFactories
{
    public  class TraceLogFactory : ILogFactory
    {
        public ILog CreateFor(Type type)
        {
            return new TraceLogger();
        }

        private class TraceLogger : ILog
        {
            public void Info(string message)
            {
                Trace.TraceInformation(message);
            }

            public void Warning(string message)
            {
                Trace.TraceWarning(message);
            }

            public void Error(string message)
            {
                Trace.TraceError(message);
            }

            public void Info(string message, params string[] args)
            {
                Trace.TraceInformation(message, args);
            }

            public void Warning(string message, params string[] args)
            {
                Trace.TraceWarning(message, args);
            }

            public void Error(string message, params string[] args)
            {
                Trace.TraceError(message, args);
            }

            public void Error(string message, Exception ex, params string[] args)
            {
                //The exception should probably be printed better....
                Trace.TraceError(message + "\n\n" + ex.Message + "\n\n" + ex.StackTrace, args);
            }

            public void Error(string message, Exception ex)
            {
                //The exception should probably be printed better....
                Trace.TraceError(message + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
            }

            public void Error(Exception ex)
            {
                //The exception should probably be printed better....
                Trace.TraceError(ex.Message + "\n\n" + ex.StackTrace);
            }
        }
    }
}

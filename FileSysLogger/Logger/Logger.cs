using System;
using log4net;
using log4net.Config;

namespace FileSysLogger.Logger
{
    /// <summary>
    /// A class that provides logging using log4net package
    /// </summary>
    public class Logger : ILogger
    {
        private readonly ILog _log;

        /// <summary>
        /// Create instance of Logger type
        /// </summary>
        /// <param name="logger">log4net provider</param>
        public Logger(ILog logger)
        {
            this._log = logger;
        }

        /// <summary>
        /// Initials logger from configuration file
        /// </summary>
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// loggs information using log4net ILog provider for debug level information
        /// </summary>
        /// <param name="exception">exception's information that will logged</param>
        public void Debug(Exception exception)
        {
            this._log.Debug(exception);
        }

        /// <summary>
        /// loggs information using log4net ILog provider for debug level information
        /// </summary>
        /// <param name="message">message that will logged</param>
        public void Debug(string message)
        {
            this._log.Debug(message);
        }

        /// <summary>
        /// loggs information using log4net ILog provider for debug level information
        /// </summary>
        /// <param name="message">message that will logged</param>
        /// <param name="exception">exception's information that will logged</param>
        public void Debug(string message, Exception exception)
        {
            this._log.Debug(message, exception);
        }

        /// <summary>
        /// loggs information using log4net ILog provider for info level information
        /// </summary>
        /// <param name="message">message that will logged</param>
        public void Info(string message)
        {
            this._log.Info(message);
        }
    }
}

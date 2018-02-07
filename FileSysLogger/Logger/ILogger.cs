using System;

namespace FileSysLogger.Logger
{
    /// <summary>
    /// Provide logging
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// loggs information of debug level
        /// </summary>
        /// <param name="message">message that will logged</param>
        void Debug(string message);

        /// <summary>
        /// loggs information of debug level
        /// </summary>
        /// <param name="message">message that will logged</param>
        /// <param name="exception">exception's information that will logged</param>
        void Debug(string message, Exception exception);

        /// <summary>
        /// loggs information of debug level
        /// </summary>
        /// <param name="exception">exception's information that will logged</param>
        void Debug(Exception exception);

        /// <summary>
        /// loggs information of info level
        /// </summary>
        /// <param name="message">message that will logged</param>
        void Info(string message);
    }
}

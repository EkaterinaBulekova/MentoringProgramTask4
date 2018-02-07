using System.Globalization;

namespace FileSysConfigurator.Configurators
{
    /// <summary>
    /// Interface that provide configuration information
    /// </summary>
    public interface ICultureConfigurator
    {
        /// <summary>
        /// Get Culture from configuration file
        /// </summary>
        CultureInfo Culture { get; }

        /// <summary>
        /// Set current culture to application
        /// </summary>
        void SetCurrentCulture();

        /// <summary>
        /// Set current culture to application
        /// </summary>
        /// <param name="name">Name of new culture</param>
        void SetCurrentCulture(string name);
    }
}

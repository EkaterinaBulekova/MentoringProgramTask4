using System;
using System.Configuration;
using System.Globalization;
using System.Text;
using FileSysConfigurator.Configuration;

namespace FileSysConfigurator.Configurators
{
    /// <summary>
    /// A class that represents all configuration information
    /// </summary>
    public class CultureConfigurator : ICultureConfigurator
    {
        private readonly FileSysConfiguration _userConfiguration;

        /// <summary>
        /// Create instance of Configurator type
        /// </summary>
        public CultureConfigurator() => this._userConfiguration = (FileSysConfiguration)ConfigurationManager
                                                            .GetSection("FileSysConfigurationSection");

        /// <summary>
        /// Get Culture that set up in application config file
        /// </summary>
        public CultureInfo Culture => new CultureInfo(this._userConfiguration.CultureName);

        /// <summary>
        /// Set Current culture to application
        /// </summary>
        public void SetCurrentCulture()
        {
            CultureInfo.DefaultThreadCurrentUICulture = Culture;
            CultureInfo.DefaultThreadCurrentCulture = Culture;
            Console.OutputEncoding = Encoding.Unicode;
        }

        /// <summary>
        /// Set Current culture to application
        /// </summary>
        /// <param name="name">Name of new culture</param>
        public void SetCurrentCulture(string name)
        {
            var culture = new CultureInfo(name);
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            Console.OutputEncoding = Encoding.Unicode;
        }
    }
}

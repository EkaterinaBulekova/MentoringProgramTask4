using System.Configuration;

namespace FileSysConfigurator.Configuration
{
    /// <summary>
    /// Represent watched directory's name
    /// </summary>
    internal class WatchedDirectory : ConfigurationElement
    {
        /// <summary>
        /// Get directory's name
        /// </summary>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string DirectoryName => (string) base["name"];
    }
}

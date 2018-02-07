using System.Configuration;

namespace FileSysConfigurator.Configuration
{
    /// <summary>
    ///  Represents a configuration section element which contains all configuration settings
    /// </summary>
    internal class FileSysConfiguration : ConfigurationSection
    {
        /// <summary>
        /// Get default directory's path
        /// </summary>
        [ConfigurationProperty("default")]
        public string DefaultDirectory => (string)base["default"];

        /// <summary>
        /// Get Culture's name
        /// </summary>
        [ConfigurationProperty("culture")]
        public string CultureName => (string)base["culture"];

        /// <summary>
        /// Get Collections of watched directories
        /// </summary>
        [ConfigurationCollection(typeof(WatchedDirectory), AddItemName = "directory")]
        [ConfigurationProperty("directories")]
        public WatcherDirectoryCollection WatchedDirectories => (WatcherDirectoryCollection)this["directories"];

        /// <summary>
        /// Get Collections of rules to move files
        /// </summary>
        [ConfigurationCollection(typeof(FileMoveRule), AddItemName = "rule")]
        [ConfigurationProperty("rules")]
        public FileMoveRuleCollection FileMoveRules => (FileMoveRuleCollection)this["rules"];
    }
}

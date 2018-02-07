using System.Configuration;

namespace FileSysConfigurator.Configuration
{
    /// <summary>
    /// Represents ConfigurationElementCollection of WatchedDirectory types
    /// </summary>
    internal class WatcherDirectoryCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WatchedDirectory();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WatchedDirectory)element).DirectoryName;
        }
    }
}

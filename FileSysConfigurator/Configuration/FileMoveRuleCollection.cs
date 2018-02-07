using System.Configuration;

namespace FileSysConfigurator.Configuration
{
    /// <summary>
    /// Represent ConfigurationElementCollection of FileMoveRule types
    /// </summary>
    internal class FileMoveRuleCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileMoveRule();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileMoveRule) element).FileNamePattern;
        }
    }
}

using System.Configuration;

namespace FileSysConfigurator.Configuration
{
    /// <summary>
    /// Represents a configuration element which contains rule to move file
    /// </summary>
    public class FileMoveRule : ConfigurationElement
    {
        /// <summary>
        /// Get Pattern for Filename
        /// </summary>
        [ConfigurationProperty("filePattern", IsKey = true, IsRequired = true)]
        public string FileNamePattern => (string)base["filePattern"];

        /// <summary>
        /// Get Destination directory's path
        /// </summary>
        [ConfigurationProperty("destination", IsRequired = true)]
        public string TargetDirectoryName => (string)base["destination"];

        /// <summary>
        /// Get flag for add Index to name of Destination file or not
        /// </summary>
        [ConfigurationProperty("addIndex", IsRequired = false, DefaultValue = false)]
        public bool AddIndexNumber => (bool)this["addIndex"];

        /// <summary>
        /// Get flag for add Date to name of Destination file or not
        /// </summary>
        [ConfigurationProperty("addDate", IsRequired = false, DefaultValue = false)]
        public bool AddDateCreation => (bool)this["addDate"];
    }
}

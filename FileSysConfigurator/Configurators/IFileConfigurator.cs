using System.Collections.Generic;
using FileSysConfigurator.Configuration;

namespace FileSysConfigurator.Configurators
{
    /// <summary>
    /// Interface that provide configuration information
    /// </summary>
    public interface IFileConfigurator
    {
        /// <summary>
        /// Get Default Directory to move file from configuration file 
        /// </summary>
        string DefaultDirectory { get; }

        /// <summary>
        /// Get List of watched directories
        /// </summary>
        List<string> WatchedDirectories { get; }

        /// <summary>
        /// Get List of rules to move files
        /// </summary>
        List<FileMoveRule> ForMoveRules { get; }

        /// <summary>
        /// Search rule to move file
        /// </summary>
        /// <param name="fileName">file's name to search</param>
        /// <returns>return rule if it's found or null</returns>
        FileMoveRule GetFileMoveRule(string fileName);
    }
}

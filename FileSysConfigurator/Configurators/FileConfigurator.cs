using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using FileSysConfigurator.Configuration;
using System.Text.RegularExpressions;

namespace FileSysConfigurator.Configurators
{
    public class FileConfigurator : IFileConfigurator
    {
        private readonly FileSysConfiguration _userConfiguration;

        /// <summary>
        /// Create instance of Configurator type
        /// </summary>
        public FileConfigurator() => _userConfiguration = (FileSysConfiguration)ConfigurationManager
            .GetSection("FileSysConfigurationSection");

        /// <summary>
        /// Get Default directory to move files
        /// </summary>
        public string DefaultDirectory => this._userConfiguration.DefaultDirectory;

        /// <summary>
        /// Get list of watched directory's paths
        /// </summary>
        public List<string> WatchedDirectories => this._userConfiguration.WatchedDirectories.Cast<WatchedDirectory>()
            .Select(_ => _.DirectoryName).ToList();

        /// <summary>
        /// Get list of rules to move files
        /// </summary>
        public List<FileMoveRule> ForMoveRules => this._userConfiguration.FileMoveRules.Cast<FileMoveRule>().ToList();

        /// <summary>
        /// Search rule into ForMoveRules to move file
        /// </summary>
        /// <param name="fileName">file's name to search</param>
        /// <returns>return rule if it's found or null</returns>
        public FileMoveRule GetFileMoveRule(string fileName)
        {
            return ForMoveRules
                .FirstOrDefault(rule => rule.FileNamePattern != null && new Regex(rule.FileNamePattern).IsMatch(fileName));
        }
    }
}

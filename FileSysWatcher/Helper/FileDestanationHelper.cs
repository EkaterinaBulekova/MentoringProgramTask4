using System;
using System.IO;
using FileSysConfigurator.Configuration;

namespace FileSysMover.Helper
{
    /// <summary>
    /// Help work with FileMoveRule type
    /// </summary>
    internal static class FileDestinationHelper
    {
        /// <summary>
        /// Extention for FileMoveRule that determines the destination directory
        /// </summary>
        /// <param name="rule">Rule to move file</param>
        /// <returns>Destination directory</returns>
        public static string GetDirectory(this FileMoveRule rule)
        {
            return rule.TargetDirectoryName;
        }

        /// <summary>
        /// Extention for FileMoveRule that determines the prefix of the AddIndexNumber flag into the rule
        /// </summary>
        /// <param name="rule">Rule to move file</param>
        /// <returns>Prefix added to filename</returns>
        public static string GetPrefix(this FileMoveRule rule)
        {
            return !rule.AddIndexNumber ? string.Empty : !Directory.Exists(rule.GetDirectory())
                    ? "1-"
                    : Directory.GetFiles(rule.GetDirectory()).Length + 1 + "-";
        }

        /// <summary>
        /// Extention for FileMoveRule that determines the postfix of the AddIndexNumber flag into the rule
        /// </summary>
        /// <param name="rule">Rule to move file</param>
        /// <returns>Postfix added to filename</returns>
        public static string GetPostfix(this FileMoveRule rule)
        {
            return !rule.AddDateCreation
                ? string.Empty
                : DateTime.Today.Date.ToString("dd-MM-yy");
        }
    }
}

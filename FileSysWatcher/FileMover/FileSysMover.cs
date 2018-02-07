using System;
using System.Globalization;
using System.IO;
using FileSysConfigurator.Configurators;
using FileSysMover.Resources;
using FileSysLogger.Logger;
using FileSysMover.Helper;

namespace FileSysMover.FileMover
{
    /// <summary>
    /// A class to watch some directories and according to the rules move file are created into them 
    /// </summary>
    public class FileSysMover : IFileSysMover
    {
        private readonly IFileConfigurator _configurator;
        private readonly ILogger _logger;

        /// <summary>
        /// Create instance of FileSysMover
        /// </summary>
        /// <param name="configurator">IFileConfigurator to provide configuration settings</param>
        /// <param name="logger">Ilogger to provide loging to file and console</param>
        public FileSysMover(IFileConfigurator configurator, ILogger logger)
        {
            _configurator = configurator;
            _logger = logger;
        }

        /// <summary>
        /// Start process to watch directory and move file
        /// </summary>
        public void FileSysMoveStart()
        {
            _logger.Info(Messages.WatchedDirectory + string.Join(",", _configurator.WatchedDirectories));
            _configurator.WatchedDirectories.ForEach(_ =>
            {
                if (_ != null)
                    new FileSystemWatcher(_)
                    {
                        EnableRaisingEvents = true,
                        NotifyFilter =
                            NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite
                    }.Created += FileSystemWatcher_Created;
            });
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            _logger.Info($@"{Messages.NewFileFound} {e.Name} {new FileInfo(e.FullPath).CreationTime}");
            MoveFile(e.FullPath, GetdestinationPath(e.Name));
        }

        private string GetdestinationPath(string name)
        {
            var fileMoveRule = _configurator.GetFileMoveRule(name);

            if (string.IsNullOrWhiteSpace(fileMoveRule?.TargetDirectoryName))
            {
                _logger.Info(Messages.RightRuleNotFound);
                return Path.Combine(_configurator.DefaultDirectory, name);
            }

            _logger.Info(Messages.RightRuleFound);
            name = fileMoveRule.GetPrefix() + Path.GetFileNameWithoutExtension(name) 
                   + fileMoveRule.GetPostfix() + Path.GetExtension(name);

            return Path.Combine(fileMoveRule.GetDirectory(), name);
        }

        private void MoveFile(string source, string destination)
        {
            try
            {
                var directory = Path.GetDirectoryName(destination);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory ?? throw new InvalidOperationException());
                }

                if (File.Exists(destination))
                {
                    File.Delete(destination);
                }

                File.Move(source, destination);
                _logger.Info($@"{Messages.TransferringFile} from {source} to {destination} {DateTime.Today.Date}");
            }
            catch (Exception exception)
            {
                _logger.Debug(Messages.UnexpectedError + DateTime.Today.Date.ToString(CultureInfo.CurrentCulture), exception);
            }

        }
    }
}

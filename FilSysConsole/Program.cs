using System;
using FileSysConfigurator.Configurators;
using FileSysConfigurator.Module;
using FileSysMover.FileMover;
using FilSysConsole.Resources;
using FileSysMover.Module;
using FileSysLogger.Module;
using Ninject;

namespace FilSysConsole
{
    /// <summary>
    /// Class for test Configuring, Logging and work with File System
    /// </summary>
    internal class Program
    {
        private static ICultureConfigurator _conf;
        private static IFileSysMover _mover;

        private static void Main()
        {
            InitialDependecy();
            _conf.SetCurrentCulture();
            Console.WriteLine(Messages.Hello);
            Console.WriteLine(Messages.CultureType + _conf.Culture.DisplayName);
            Console.WriteLine(Messages.ForCultureChange);
            var inputKey = Console.ReadKey(true);
            if (inputKey.Key == ConsoleKey.Y)
            {
                _conf.SetCurrentCulture(_conf.Culture.Name == "ru-RU" ? "en-EN" : "ru-RU");
            }

            _mover.FileSysMoveStart();
            Console.WriteLine(Messages.ForExit);
            Console.CancelKeyPress += (o, e) => Environment.Exit(0);
            WatingCancelKeyPress();
        }

        private static void InitialDependecy()
        {
            IKernel kernel =
            new StandardKernel(new FileMoverModule(), new ConfiguratorModule(), new FileSysLoggerModule());
            _conf = kernel.Get<ICultureConfigurator>();
            _mover = kernel.Get<IFileSysMover>();
        }

        private static void WatingCancelKeyPress()
        {
            while (true)
            {
                Console.ReadKey(true);
            }
        }
    }
}


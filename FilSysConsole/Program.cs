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
        private static readonly IKernel Kernel =
            new StandardKernel(new FileMoverModule(), new ConfiguratorModule(), new FileSysLoggerModule());
        private static readonly ICultureConfigurator Conf = Kernel.Get<ICultureConfigurator>();
        private static readonly IFileSysMover Mover = Kernel.Get<IFileSysMover>();

        private static void Main()
        {
            Console.CancelKeyPress += (o, e) => Environment.Exit(0);
            Conf.SetCurrentCulture();
            Console.WriteLine(Messages.Hello);
            Console.WriteLine(Messages.CultureType + Conf.Culture.DisplayName);
            Console.WriteLine(Messages.ForCultureChange);
            var inputKey = Console.ReadKey(true);
            if (inputKey.Key == ConsoleKey.Y)
            {
                Conf.SetCurrentCulture(Conf.Culture.Name == "ru-RU" ? "en-EN" : "ru-RU");
            }

            Mover.FileSysMoveStart();
            Console.WriteLine(Messages.ForExit);
            while (true)
            {
                Console.ReadKey(true);
            }
        }
    }
}


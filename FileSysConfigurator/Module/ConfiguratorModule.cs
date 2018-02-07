using FileSysConfigurator.Configurators;

namespace FileSysConfigurator.Module
{
    public class ConfiguratorModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICultureConfigurator>().To<CultureConfigurator>();
            Bind<IFileConfigurator>().To<FileConfigurator>();
        }
    }
}

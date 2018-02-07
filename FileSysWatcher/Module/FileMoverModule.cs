using FileSysMover.FileMover;


namespace FileSysMover.Module
{
    public class FileMoverModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IFileSysMover>().To<FileMover.FileSysMover>();
        }
    }
}

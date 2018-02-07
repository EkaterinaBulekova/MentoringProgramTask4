using log4net;
using FileSysLogger.Logger;

namespace FileSysLogger.Module
{
    public class FileSysLoggerModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(ctx => LogManager.GetLogger(ctx.Request.Target?.Member.DeclaringType));
            Bind<ILogger>().To<Logger.Logger>();
        }
    }
}

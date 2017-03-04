using Autofac;

namespace Caliburn.Micro.Training.Common
{
    public class CommonDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemDateTimeProvider>().As<IDateTimeProvider>();
        }
    }
}

using System.Configuration;
using Autofac;
using Caliburn.Micro.Training.Infrastructure.Database;
using Caliburn.Micro.Training.Infrastructure.Repository;

namespace Caliburn.Micro.Training.Infrastructure
{
    public class InfrastructureDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["TrainingData"].ConnectionString;
            builder.RegisterType<DatabaseSqlConnectionFactory>().As<IDatabaseSqlConnectionFactory>().WithParameter(new TypedParameter(typeof(string), dbConnectionString));
            builder.RegisterType<UserRepository>().AsImplementedInterfaces();
        }
    }
}

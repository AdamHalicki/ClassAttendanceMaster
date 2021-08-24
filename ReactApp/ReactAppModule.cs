using Autofac;
using Microsoft.Extensions.Logging;
using ReactApp.Initializers;
using Serilog.Extensions.Logging;

namespace ReactApp
{
    public class ReactAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SerilogLoggerFactory>().As<ILoggerFactory>().SingleInstance();

            builder.RegisterType<StudentInitializer>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<RoleInitializer>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UserInitializer>().AsSelf().InstancePerLifetimeScope();
        }
    }
}

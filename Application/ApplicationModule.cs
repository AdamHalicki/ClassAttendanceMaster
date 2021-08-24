using Application.Services.Implementations;
using Autofac;

namespace Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UserService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}

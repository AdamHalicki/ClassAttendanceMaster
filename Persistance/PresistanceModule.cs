using Autofac;
using Domain.Repositiories;
using Microsoft.EntityFrameworkCore;
using Persistance.DbContextOptionsProviders;
using Persistance.Repositories;

namespace Persistance
{
    public class PresistanceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SqlLiteDbContextOptionsProvider<ClassAttendanceDbContext>>()
                .As<DbContextOptionsProvider<ClassAttendanceDbContext>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.Register(context => context.Resolve<DbContextOptionsProvider<ClassAttendanceDbContext>>().CreateInstance())
                .As<DbContextOptions<ClassAttendanceDbContext>>()
                .As<DbContextOptions>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassAttendanceDbContext>()
                .As<DbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .As(typeof(IInternalRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}

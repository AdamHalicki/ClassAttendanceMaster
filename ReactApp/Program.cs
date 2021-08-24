using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactApp.Initializers;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace ReactApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var dbContext = serviceProvider.GetRequiredService<DbContext>();
                var studentInitializer = serviceProvider.GetRequiredService<StudentInitializer>();
                var roleInitializer = serviceProvider.GetRequiredService<RoleInitializer>();
                var userInitializer = serviceProvider.GetRequiredService<UserInitializer>();

                try
                {
                    Task.Run(async () =>
                    {
                        await dbContext.Database.MigrateAsync();

                        await studentInitializer.SeedStudentsAsync();
                        //await roleInitializer.SeedRolesAsync();
                        //await userInitializer.SeedUsersAsync();
                    })
                        .ConfigureAwait(true)
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception exception)
                {
                    Log.Error(exception, "Initialie error");
                }
            }

            Log.Information("Starting web host");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    config.AddJsonFile("Settings/appsettings.json", false, true);
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

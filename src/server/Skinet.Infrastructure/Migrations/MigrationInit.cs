using System;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Skinet.Infrastructure.Migrations
{
    public static class MigrationInit
    {
        public static IServiceCollection AddMigrations(this IServiceCollection services, string connectionString)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(x =>
                {
                    x.ScanIn(Assembly.GetExecutingAssembly()).For.Migrations();
                    x.ScanIn(Assembly.GetExecutingAssembly()).For.EmbeddedResources();
                    x.WithGlobalConnectionString(connectionString);
                    x.AddSQLite();
                })
                .AddLogging(l => l.AddFluentMigratorConsole());

            return services;
        }

        public static IApplicationBuilder InitMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                ExecuteMigrations(runner);
                return app;
            }
        }

        private static void ExecuteMigrations(IMigrationRunner runner)
        {
            using (var runnerScope = runner.BeginScope())
            {
                try
                {
                    runner.MigrateUp();
                    runnerScope.Complete();
                }
                catch (Exception e)
                {
                    runnerScope.Cancel();
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
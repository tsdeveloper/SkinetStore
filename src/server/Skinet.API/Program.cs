using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Skinet.Core.Entities.Base;

namespace Skinet.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IHost BuildWebHost(string[] args)
        {
            var appSettingsProfile = Environment.GetEnvironmentVariable(BaseEnviromentProfile.APPSETTINGS_PROFILE);
            var jsonBase = BaseEnviromentProfile.APPSETTINGS_JSONBASE;
            
            
            if (!string.IsNullOrWhiteSpace(appSettingsProfile))
                jsonBase = $"appsettings_{appSettingsProfile}";

            
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddJsonFile(jsonBase)
                .Build();
        
            
            var env = config["environment"] ?? BaseEnviromentProfile.APPSETTINGS_ENVIRONMENT_DEVELOPMENT;


           return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseEnvironment(env);
                    webBuilder.UseStartup<Startup>();
                })
                .Build();

        }
    }
}

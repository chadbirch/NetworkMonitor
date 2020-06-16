using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetworkMonitor.Library.Configuration;

namespace NetworkMonitor.WindowsService
{
    public class WindowsService
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var configuration = ConfigurationHelper.GetConfiguration();

            Library.Logging.Logger.CreateLogger<WindowsService>(configuration);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}

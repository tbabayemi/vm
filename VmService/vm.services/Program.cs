using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace vm.services
{
    public class Program
    {
        private static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            var directory = Directory.GetParent(Directory.GetCurrentDirectory());
            var nlogConfigPath = Path.Combine(directory.FullName, "nlog.config");
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(nlogConfigPath).GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");

                // ASP.NET Core 3.0+:
                // The UseServiceProviderFactory call attaches the
                // Autofac provider to the generic hosting mechanism.
                var host = Host.CreateDefaultBuilder(args)
                    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureWebHostDefaults(webHostBuilder => {
                        webHostBuilder
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseIISIntegration()
                  .UseStartup<Startup>();
                    }).ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    }).UseNLog()
                   .Build();
         
                host.Run();
            } catch(Exception exp)
            {
                logger.Error(exp, "Stopped program of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }         
            
        }

    }
}

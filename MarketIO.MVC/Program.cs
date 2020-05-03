using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace MarketIO.MVC
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var _logger = NLogBuilder
               .ConfigureNLog("nlog.config")
               .GetCurrentClassLogger();
            try
            {
                var host = CreateHostBuilder(args).Build();

                // migrate the database.  Best practice = in Main, using service scope
                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var context = scope.ServiceProvider.GetService<MarketIODbContext>();
                        context.Database.EnsureCreated();
                        context.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while migrating the database.");
                    }
                }

                // run the web app
                host.Run();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "App Stopped because exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseNLog();
                });
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketIO.MVC.Instrallers
{
    public static class InstallerExtension 
    {
        public static void InstallServicesInAssemply( this  IServiceCollection services , IConfiguration configuration)
        {
            var Installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            Installers.ForEach(installer => {
                installer.InstallServices(services, configuration); 
            });
        }
    }
}

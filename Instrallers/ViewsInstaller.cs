using AutoMapper;
using MarketIO.MVC.Domain;
using MarketIO.MVC.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarketIO.MVC.Instrallers
{
    public class ViewsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddSession();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

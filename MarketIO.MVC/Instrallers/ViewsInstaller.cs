using AutoMapper;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarketIO.MVC.Instrallers
{
    public class ViewsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews(o=> o.Filters.Add(new AuthorizeFilter()));
            services.AddHttpContextAccessor();
            services.AddSession();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

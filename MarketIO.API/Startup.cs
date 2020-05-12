using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketIO.API.Installers;
using MarketIO.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MarketIO.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssemply(Configuration);
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("EnableCors");
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthorization();
            var swaggerSettings = new SwaggerSettings();
            Configuration.GetSection(nameof(SwaggerSettings)).Bind(swaggerSettings);
            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerSettings.JsonRoute;
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerSettings.UIEndPoint, swaggerSettings.Description);

                options.DocumentTitle = "MarketIO";
                options.DocExpansion(DocExpansion.None);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

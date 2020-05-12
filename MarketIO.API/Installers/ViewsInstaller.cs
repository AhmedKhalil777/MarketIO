using MarketIO.API.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.API.Installers
{
    public class ViewsInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var swaggerSettings = new SwaggerSettings();
            configuration.GetSection(nameof(SwaggerSettings)).Bind(swaggerSettings);
            services.AddSwaggerGen(settings => {
                var security = new  OpenApiSecurityRequirement();
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = "Using Bearer Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey

                };
                security.Add(securityScheme, new List<string>() { });
                settings.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo() { 
                    Description = swaggerSettings.Description,
                    Version = "V1",
                    Title = "MarketIO"
                });
                settings.AddSecurityDefinition("Bearer" , securityScheme);
                settings.AddSecurityRequirement(security);
            });
            services.AddControllers();
        }


    }
}

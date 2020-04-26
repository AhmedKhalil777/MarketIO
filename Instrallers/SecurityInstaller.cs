using MarketIO.MVC.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Instrallers
{
    public class SecurityInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region JWT Authentication
            var appSettingsSection = configuration.GetSection("JWTSettings");
            services.Configure<JwtSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            // Authintication Middleware
            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.Site,
                    ValidAudience = appSettings.Audience,

                    IssuerSigningKey = new SymmetricSecurityKey(key)


                };
            });

            #endregion

            #region CORS Policy
            services.AddCors(options => {
                options.AddPolicy("EnableCors", PolicyBuilder => {
                    PolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod().AllowCredentials().Build();
                });
            });
            #endregion

            #region Authorization
            services.AddAuthorization(options => {
                // Require authontication first from all roles
                options.AddPolicy("RequireLoggedin", policy => policy.RequireRole("Customer", "Moderator", "Admin").RequireAuthenticatedUser());
                // Require admin to do managment operations just
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin").RequireAuthenticatedUser());

            });
            #endregion 

        }
    }
}

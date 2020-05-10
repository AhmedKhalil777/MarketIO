using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MarketIO.API.Installers
{
    public class SecurityInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(schemes =>
            {
                schemes.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                schemes.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = SymmetricSecurityKey();
                };
            
            });
        }
    }
}

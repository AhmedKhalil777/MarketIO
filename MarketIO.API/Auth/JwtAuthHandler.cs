using MarketIO.API.Settings;
using MarketIO.DAL.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.API.Auth
{
    public class JwtAuthHandler
    {
        private readonly IConfiguration _configuration;
        public JwtAuthHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(Customers customer , string Role)
        {
            JwtSettings _settings = new JwtSettings();
            
            _configuration.GetSection(nameof(JwtSettings)).Bind(_settings);
            var tokenHendler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Secret));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, customer.Email),
                    new Claim(ClaimTypes.Name, customer.UserName),
                    new Claim(ClaimTypes.Role, Role)
                }),
                Expires = DateTime.Now.AddMinutes(_settings.Expired),
                Audience = _settings.Audience,
                Issuer = _settings.Issuer,
                SigningCredentials = new SigningCredentials(key ,SecurityAlgorithms.HmacSha256),
                IssuedAt = DateTime.Now
                
            };

            var token = tokenHendler.CreateToken(tokenDescriptor);
            return tokenHendler.WriteToken(token);
        }
    }
}

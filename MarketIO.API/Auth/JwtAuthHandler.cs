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
        private readonly JwtSettings _settings;
        public JwtAuthHandler(IConfiguration configuration)
        {
            configuration.GetSection(nameof(JwtSettings)).Bind(_settings);
        }
        public string CreateToken(Customers customer , string Role)
        {
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

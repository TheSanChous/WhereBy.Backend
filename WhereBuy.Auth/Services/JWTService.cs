using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhereBuy.Auth.Models;
using WhereBuy.Common.Configuration;
using WhereBuy.Domain;

namespace WhereBuy.Auth.Services
{
    public class JWTService : IJWTService
    {
        private const string PointsClaimName = "Points";

        private readonly JWTConfiguration configuration;

        public JWTService(JWTConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Tokens> GetTokensAsync(User user, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    //new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
					//new Claim(ClaimTypes.MobilePhone, user.Phone),
					new Claim(PointsClaimName, user.Points.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}

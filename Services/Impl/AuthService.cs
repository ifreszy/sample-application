using Entity.Models;
using Microsoft.IdentityModel.Tokens;
using Services.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly AuthSettings _settings;
        public AuthService(AuthSettings settings) 
        { 
            _settings = settings;
        }
        public string GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new []
                {
                   new Claim(type: ClaimTypes.Name, value: user.Login)
                }),
                Expires = DateTime.UtcNow.AddHours(_settings.ExpiresIn),
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

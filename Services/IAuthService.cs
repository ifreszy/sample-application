using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAuthService
    {
        string GenerateToken(UserModel user);
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        void SaveRefreshToken(string username, string refreshToken);
        ClaimsPrincipal GetPrincipalFromToken(string token);
        string GetRefreshToken(string username);
        void DeleteRefreshToken(string username, string refreshToken);
    }
}

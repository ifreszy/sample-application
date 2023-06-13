using AutoMapper;
using DTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Impl;

namespace sample_application.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;   
        public AuthController(IAuthService authService, IMapper mapper, IUserService userService)
        {
            _authService = authService; 
            _mapper = mapper;   
            _userService = userService;
        }

        [Route("auth")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authorize(UserAuthDTO user)
        {
            var userModel = _userService.GetUserByLogin(user.Login);

            if (userModel == null || !userModel.Password.Equals(user.Password)) 
            {
                return BadRequest("Invalid login/password");
            }

            var token = _authService.GenerateToken(userModel);
            var refreshToken = _authService.GenerateRefreshToken();
            _authService.SaveRefreshToken(userModel.Login, refreshToken);

            return Ok(new
            {
                token,
                user = _mapper.Map<UserDTO>(userModel),
                refreshToken
            });
        }

        [Route("auth/refresh")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Refresh(RefreshTokenDTO refreshToken)
        {
            var principal = _authService.GetPrincipalFromToken(refreshToken.Token);
            var login = principal.Identity.Name;

            var cacheRefreshToken = _authService.GetRefreshToken(login);

            if (refreshToken.RefreshToken != cacheRefreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newToken = _authService.GenerateToken(principal.Claims);
            var newRefreshToken = _authService.GenerateRefreshToken();
            _authService.DeleteRefreshToken(login, refreshToken.RefreshToken);
            _authService.SaveRefreshToken(login, newRefreshToken);

            return Ok(new
            {
                token = newToken,
                refreshToken = newRefreshToken
            });
        }

    }
}

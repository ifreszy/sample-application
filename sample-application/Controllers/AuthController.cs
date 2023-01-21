using AutoMapper;
using DTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Route("Auth")]
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

            return Ok(new
            {
                token,
                user = _mapper.Map<UserDTO>(userModel)
            });
        }

    }
}

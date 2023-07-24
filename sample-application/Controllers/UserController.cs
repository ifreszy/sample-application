using AutoMapper;
using DTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_application.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            var users = _userService.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserModel>, IEnumerable <UserDTO>>(users));
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public ActionResult<UserDTO> CreateUser(CreateUserDTO user)
        {
            var newUser = _userService.SaveUser(user);

            return Ok(_mapper.Map<UserModel, UserDTO>(newUser));
        }
    }
}

using AutoMapper;
using DTO;
using Entity.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper; 
        }

        public UserModel GetUserByLogin(string login)
        {
            return _userRepository.GetUserByLogin(login);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public UserModel SaveUser(CreateUserDTO user) 
        {
            //TODO - Data validation

            var userModel = _mapper.Map<CreateUserDTO, UserModel>(user);

            return _userRepository.SaveUser(userModel);
        }
        
    }
}

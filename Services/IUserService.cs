using DTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        public IEnumerable<UserModel> GetUsers();
        public UserModel SaveUser(CreateUserDTO user);
        public UserModel GetUserByLogin(string login);
    }
}

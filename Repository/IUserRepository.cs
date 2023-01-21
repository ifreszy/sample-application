using DTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel SaveUser(UserModel user);
        UserModel GetUserByLogin(string login);
    }
}

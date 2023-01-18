using Data.Database;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbCustomConnection _connection;
        public UserRepository(IDbCustomConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            string sql = "SELECT * FROM USERS";

            return _connection.Query<UserModel>(sql);
        }
    }
}

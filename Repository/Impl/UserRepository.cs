using Data.Database;
using DTO;
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

        public UserModel GetUserByLogin(string login)
        {
            string sql = "SELECT * FROM users WHERE login = :login";

            return _connection.QuerySingle<UserModel>(sql, new { login });
        }

        public IEnumerable<UserModel> GetUsers()
        {
            string sql = "SELECT * FROM USERS";

            return _connection.Query<UserModel>(sql);
        }

        public UserModel SaveUser(UserModel user)
        {
            string sql = @"INSERT INTO USERS (Name, Email, Login, Password, Bio)
                            VALUES
                            (:Name, :Email, :Login, :Password, :Bio) RETURNING Id";
            
            user.Id = _connection.ExecuteScalar<long>(sql, user);

            return user;
        }
    }
}

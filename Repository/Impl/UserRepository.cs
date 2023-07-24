using ApplicationContext;
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
        private readonly DatabaseContext _dbContext;
        private readonly string SQL_SEQUENCE = "SELECT USERS_SEQ.CURRVAL FROM DUAL";
        public UserRepository(IDbCustomConnection connection, DatabaseContext dbContext)
        {
            _connection = connection;
            _dbContext = dbContext;
        }

        public UserModel GetUserByLogin(string login)
        {
            return _dbContext.Users.Where(user => user.Login == login).FirstOrDefault();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public UserModel SaveUser(UserModel user)
        {
            string sql;

            if (_connection.DataBaseType == Data.Database.Utils.DataBaseType.POSTGRESQL) 
            {
                sql = @"INSERT INTO USERS (NAME, EMAIL, LOGIN, PASSWORD, BIO)
                        VALUES
                        (:Name, :Email, :Login, :Password, :Bio) returning ID";

                user.Id = _connection.ExecuteScalar<long>(sql, user);
            }
            else
            {
                sql = @"INSERT INTO USERS (NAME, EMAIL, LOGIN, PASSWORD, BIO)
                        VALUES
                        (:Name, :Email, :Login, :Password, :Bio)";
                _connection.ExecuteScalar<long>(sql, user);
                user.Id = _connection.ExecuteScalar<long>(SQL_SEQUENCE);
            }

            return user;
        }
    }
}

//using ApplicationContext;
using Data.Database;
using DatabaseContext;
using DTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationContext _dbContext;
        private readonly string SQL_SEQUENCE = "SELECT USERS_SEQ.CURRVAL FROM DUAL";
        public UserRepository(IDbCustomConnection connection, ApplicationContext dbContext)
        {
            _connection = connection;
            _dbContext = dbContext;
        }

        public UserModel GetUserByLogin(string login)
        {
            return _dbContext.Users.Include(x => x.Role).Where(x => x.Login == login).FirstOrDefault();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public UserModel SaveUser(UserModel user)
        {
            string sql;

            //var guestRole = _dbContext.Roles.First(x => x.Name == "Guest");

            user.RoleId = user.RoleId.GetValueOrDefault(1);

            if (_connection.DataBaseType == Data.Database.Utils.DataBaseType.POSTGRESQL) 
            {
                sql = @"INSERT INTO USERS (NAME, EMAIL, LOGIN, PASSWORD, BIO, ROLE_ID)
                        VALUES
                        (:Name, :Email, :Login, :Password, :Bio, :RoleId) returning ID";

                user.Id = _connection.ExecuteScalar<long>(sql, user);
            }
            else
            {
                sql = @"INSERT INTO USERS (NAME, EMAIL, LOGIN, PASSWORD, BIO, ROLE_ID)
                        VALUES
                        (:Name, :Email, :Login, :Password, :Bio, :RoleId)";
                _connection.ExecuteScalar<long>(sql, user);
                user.Id = _connection.ExecuteScalar<long>(SQL_SEQUENCE);
            }

            return user;
        }
    }
}

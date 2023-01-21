using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database.Impl
{
    public class DbCustomConnection : IDbCustomConnection
    {
        private readonly IDbConnection _connection;
        public DbCustomConnection(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public int Execute(string query, object parameters = null, IDbTransaction transaction = null)
        {
            return _connection.Execute(query, parameters, transaction);
        }

        public T ExecuteScalar<T>(string query, object parameters = null, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string query, object parameters = null, IDbTransaction transaction = null)
        {
            return _connection.Query<T>(query, parameters, transaction);
        }

        public T QueryFirst<T>(string query, object parameters = null, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public T QuerySingle<T>(string query, object parameters = null, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database.Utils;

namespace Data.Database.Impl
{
    public class DbCustomConnection : IDbCustomConnection
    {
        private readonly IDbConnection _connection;
        private readonly DataBaseType _databaseType;
        public DbCustomConnection(IDbConnection connection, ConnectionSettings connectionSettings)
        {
            _connection = connection;
            _databaseType = connectionSettings.Type;
        }

        public DataBaseType DataBaseType => _databaseType;

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
            return _connection.ExecuteScalar<T>(query, parameters, transaction);   
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
            return _connection.QuerySingleOrDefault<T>(query, parameters, transaction);  
        }
    }
}

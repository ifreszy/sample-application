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

        public int Execute(string Sql, object Params = null, IDbTransaction Transacao = null)
        {
            return _connection.Execute(Sql, Params, Transacao);
        }

        public T ExecuteScalar<T>(string Sql, object Params = null, IDbTransaction Transacao = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string Sql, object Params = null, IDbTransaction Transacao = null)
        {
            return _connection.Query<T>(Sql, Params, Transacao);
        }

        public T QueryFirst<T>(string Sql, object Params = null, IDbTransaction Transacao = null)
        {
            throw new NotImplementedException();
        }

        public T QuerySingle<T>(string Sql, object Params = null, IDbTransaction Transacao = null)
        {
            throw new NotImplementedException();
        }
    }
}

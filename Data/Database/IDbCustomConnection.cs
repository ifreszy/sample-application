using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public interface IDbCustomConnection
    {
        public IEnumerable<T> Query<T>(string Sql, object Params = null, IDbTransaction Transacao = null);
        public T QueryFirst<T>(string Sql, object Params = null, IDbTransaction Transacao = null);
        public T ExecuteScalar<T>(string Sql, object Params = null, IDbTransaction Transacao = null);
        public IDbTransaction BeginTransaction();
        public T QuerySingle<T>(string Sql, object Params = null, IDbTransaction Transacao = null);
        public int Execute(string Sql, object Params = null, IDbTransaction Transacao = null);
    }
}

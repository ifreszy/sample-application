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
        public IEnumerable<T> Query<T>(string query, object parameters = null, IDbTransaction transaction = null);
        public T QueryFirst<T>(string query, object parameters = null, IDbTransaction transaction = null);
        public T ExecuteScalar<T>(string query, object parameters = null, IDbTransaction transaction = null);
        public IDbTransaction BeginTransaction();
        public T QuerySingle<T>(string query, object parameters = null, IDbTransaction transaction = null);
        public int Execute(string query, object parameters = null, IDbTransaction transaction = null);
    }
}

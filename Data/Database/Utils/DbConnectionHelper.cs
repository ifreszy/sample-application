using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database.Utils
{
    public static class DbConnectionHelper
    {
        public static IDbConnection CreateDatabaseConnection(string connectionString) => new NpgsqlConnection(connectionString);
    }
}

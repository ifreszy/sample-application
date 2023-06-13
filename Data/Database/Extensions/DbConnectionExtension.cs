using Data.Database.Impl;
using Data.Database.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database.Extensions
{
    public static class DbConnectionExtension
    {
        public static void AddDbConnection(this IServiceCollection services, string connStr, DataBaseType type = DataBaseType.POSTGRESQL)
        {
            switch (type)
            {
                case DataBaseType.POSTGRESQL:
                    if (string.IsNullOrEmpty(connStr))
                        connStr = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DATABASE").Trim();

                    if (string.IsNullOrEmpty(connStr))
                        throw new Exception("Connection string not defined"); 

                    services.AddScoped((sp) => DbConnectionHelper.CreateDatabaseConnection(connStr));
                    services.AddTransient<IDbCustomConnection, DbCustomConnection>();
                    break;
                case DataBaseType.ORACLE:
                    if (string.IsNullOrEmpty(connStr))
                        connStr = Environment.GetEnvironmentVariable("ORACLECONNSTR_DATABASE").Trim();

                    if (string.IsNullOrEmpty(connStr))
                        throw new Exception("Connection string not defined");

                    services.AddScoped((sp) => DbConnectionHelper.CreateOracleDatabaseConnection(connStr));
                    services.AddTransient<IDbCustomConnection, DbCustomConnection>();
                    break;
            }
        }
    }
}

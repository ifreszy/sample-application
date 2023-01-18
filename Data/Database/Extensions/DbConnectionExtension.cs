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
        public static void AddDbConnection(this IServiceCollection services, string connStr)
        {
            if (string.IsNullOrEmpty(connStr))
                connStr = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DATABASE");
            services.AddTransient((sp) => DbConnectionHelper.CreateDatabaseConnection(connStr));
            services.AddTransient<IDbCustomConnection, DbCustomConnection>();
        }
    }
}

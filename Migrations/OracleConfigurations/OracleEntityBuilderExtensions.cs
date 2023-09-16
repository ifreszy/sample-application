using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleConfigurations
{
    internal static class OracleEntityBuilderExtensions
    {
        internal static void ToTableName<T>(this EntityTypeBuilder<T> builder, string tableName) where T : class
        {
           
            builder.ToTable(tableName, x => x.ExcludeFromMigrations());
        }

    }
}

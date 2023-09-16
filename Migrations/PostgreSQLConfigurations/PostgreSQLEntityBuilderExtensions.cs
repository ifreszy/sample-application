using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostgreSQLConfigurations;
public static class PostgreSQLEntityBuilderExtensions
{
    public static void ToTableName<T>(this EntityTypeBuilder<T> builder, string tableName) where T : class
    {
        builder.ToTable(tableName, x => x.ExcludeFromMigrations());
    }
}

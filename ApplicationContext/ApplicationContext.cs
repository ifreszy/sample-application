using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace ApplicationContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (Database.ProviderName!.Contains("PostgreSQL"))
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("MigrationsPostgreSQL"));
            }
            else if (Database.ProviderName!.Contains("Oracle"))
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("MigrationsOracle"));
            }
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
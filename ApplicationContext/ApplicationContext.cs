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
            if (Database.ProviderName!.Contains("PostgreSQL"))
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("MigrationsPostgreSQL"));
            }
        }

        public DbSet<UserModel> Users { get; set; }
    }

    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
    }
}
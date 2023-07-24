using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsPostgreSQL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("users");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Login).HasColumnName("login");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.Bio).HasColumnName("bio");
            builder.Property(x => x.Email).HasColumnName("email");
        }
    }
}

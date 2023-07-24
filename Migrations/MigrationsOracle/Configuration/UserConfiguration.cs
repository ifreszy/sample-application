using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("USERS");
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasColumnName("NAME");
            builder.Property(x => x.Login).HasColumnName("LOGIN");
            builder.Property(x => x.Password).HasColumnName("PASSWORD");
            builder.Property(x => x.Bio).HasColumnName("BIO");
            builder.Property(x => x.Email).HasColumnName("EMAIL");
        }
    }
}

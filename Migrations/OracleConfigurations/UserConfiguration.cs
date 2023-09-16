using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OracleConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTableName("USERS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasColumnName("NAME");
            builder.Property(x => x.Login).HasColumnName("LOGIN");
            builder.Property(x => x.Password).HasColumnName("PASSWORD");
            builder.Property(x => x.Bio).HasColumnName("BIO");
            builder.Property(x => x.Email).HasColumnName("EMAIL");
            builder.Property(x => x.RoleId).HasColumnName("ROLE_ID");
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
        }
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class UsersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "users",
                    columns: table => new
                    {
                        Id = table.Column<long>(nullable: false, type: "serial", name: "id"),
                        Name = table.Column<string>(nullable: false, maxLength: 100, name: "name"),
                        Email = table.Column<string>(nullable: false, maxLength: 100, name: "email"),
                        Login = table.Column<string>(nullable: false, maxLength: 100, name: "login"),
                        Password = table.Column<string>(nullable: false, maxLength: 100, name: "password"),
                        Bio = table.Column<string>(nullable: true, maxLength: 1000, name: "bio"),
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_users", x => x.Id);
                        table.UniqueConstraint("UK_userEmail", x => x.Email);
                        table.UniqueConstraint("UK_userLogin", x => x.Login);
                    }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("users");
        }
    }
}

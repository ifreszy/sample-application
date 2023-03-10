using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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

            migrationBuilder.CreateIndex("IDX_userId", "users", "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IDX_userId", "users", "Id");
            migrationBuilder.DropTable("users");
        }
    }
}

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
                        Id = table.Column<long>(nullable: false, type: "serial"),
                        Name = table.Column<string>(nullable: false, maxLength: 100),
                        Email = table.Column<string>(nullable: false, maxLength: 100),
                        Login = table.Column<string>(nullable: false, maxLength: 100),
                        Password = table.Column<string>(nullable: false, maxLength: 100),
                        Bio = table.Column<string>(nullable: true, maxLength: 1000),
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_users", x => x.Id);
                        table.UniqueConstraint("UK_userEmail", x => x.Email);
                        table.UniqueConstraint("UK_userLogin", x => x.Login);
                    }
                );

            migrationBuilder.CreateIndex("IDX_userId", "users", "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IDX_userId", "users", "Id");
            migrationBuilder.DropTable("users");
        }
    }
}

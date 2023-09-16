using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsOracle.Migrations
{
    /// <inheritdoc />
    public partial class UsersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence("USERS_SEQ");

            migrationBuilder.CreateTable(
                    name: "USERS",
                    columns: table => new
                    {
                        Id = table.Column<long>(nullable: false, type: "NUMBER", defaultValueSql: "USERS_SEQ.nextval", name: "ID"),
                        Name = table.Column<string>(nullable: false, maxLength: 100, name: "NAME"),
                        Email = table.Column<string>(nullable: false, maxLength: 100, name: "EMAIL"),
                        Login = table.Column<string>(nullable: false, maxLength: 100, name: "LOGIN"),
                        Password = table.Column<string>(nullable: false, maxLength: 100, name: "PASSWORD"),
                        Bio = table.Column<string>(nullable: true, maxLength: 1000, name: "BIO"),
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
            migrationBuilder.DropTable("USERS");
            migrationBuilder.DropSequence("USERS_SEQ");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsOracle.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(name: "ROLE_ID",
                table: "USERS", nullable: true);

            migrationBuilder.AddForeignKey(name: "USER_ROLE_FK",
                table: "USERS",
                column: "ROLE_ID",
                principalTable: "ROLES",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("USER_ROLE_FK",
                table: "USERS");

            migrationBuilder.DropColumn("ROLE_ID",
                table: "USERS");
        }
    }
}

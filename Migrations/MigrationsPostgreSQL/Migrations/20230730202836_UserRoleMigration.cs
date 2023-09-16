using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(name: "role_id",
                table: "users", nullable: true);

            migrationBuilder.AddForeignKey(name: "USER_ROLE_FK",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("USER_ROLE_FK",
                table: "users");

            migrationBuilder.DropColumn("ROLE_ID",
                table: "users");
        }
    }
}

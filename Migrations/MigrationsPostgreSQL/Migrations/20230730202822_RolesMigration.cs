using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class RolesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, name: "id", type: "serial"),
                    Name = table.Column<string>(nullable: false, name: "name", maxLength: 30),
                    Description = table.Column<string>(nullable: false, name: "description", maxLength: 50)
                }, constraints: table =>
                {
                    table.PrimaryKey(name: "ROLES_PK", x => x.Id);
                });

            migrationBuilder.Sql(@"
                insert into roles
                (name, description)
                values
                ('Administrator', 'System Administrator');
            ");

            migrationBuilder.Sql(@"
                insert into roles
                (name, description)
                values
                ('Guest', 'Guest');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("roles");
        }
    }
}

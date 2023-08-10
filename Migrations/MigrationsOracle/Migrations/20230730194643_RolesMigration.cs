using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsOracle.Migrations
{
    /// <inheritdoc />
    public partial class RolesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence("ROLES_SEQ");

            migrationBuilder.CreateTable(name: "ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, name: "ID", defaultValueSql: "ROLES_SEQ.nextval", type: "NUMBER"),
                    Name = table.Column<string>(nullable: false, name: "NAME", type: "VARCHAR2(30)"),
                    Description = table.Column<string>(nullable: false, name: "DESCRIPTION", type: "VARCHAR2(50)")
                }, constraints: table =>
                {
                    table.PrimaryKey(name: "ROLES_PK", x => x.Id);
                });

            migrationBuilder.Sql(@"
                INSERT INTO ROLES
                (NAME, DESCRIPTION)
                VALUES
                ('Administrator', 'System Administrator');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ROLES
                (NAME, DESCRIPTION)
                VALUES
                ('Guest', 'Guest');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ROLES");
            migrationBuilder.DropSequence("ROLES_SEQ");
        }
    }
}

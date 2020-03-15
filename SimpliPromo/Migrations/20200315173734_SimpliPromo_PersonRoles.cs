using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpliPromo.Migrations
{
    public partial class SimpliPromo_PersonRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    PersonRoleId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => x.PersonRoleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRole");
        }
    }
}

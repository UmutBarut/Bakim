using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class psidforsection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionSectionId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionSectionId",
                table: "Sections");
        }
    }
}

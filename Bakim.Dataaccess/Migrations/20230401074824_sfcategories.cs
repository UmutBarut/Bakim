using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class sfcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArızaKategorileri",
                table: "ArızaKategorileri");

            migrationBuilder.RenameTable(
                name: "ArızaKategorileri",
                newName: "SectionFaultCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionFaultCategories",
                table: "SectionFaultCategories",
                column: "FaultCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionFaultCategories",
                table: "SectionFaultCategories");

            migrationBuilder.RenameTable(
                name: "SectionFaultCategories",
                newName: "ArızaKategorileri");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArızaKategorileri",
                table: "ArızaKategorileri",
                column: "FaultCategoryId");
        }
    }
}

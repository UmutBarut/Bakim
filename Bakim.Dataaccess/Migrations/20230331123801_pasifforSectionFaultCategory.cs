using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class pasifforSectionFaultCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "ArızaKategorileri",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "ArızaKategorileri");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class varlikıdforworktask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VarlikId",
                table: "WorkTasks",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VarlikId",
                table: "WorkTasks");
        }
    }
}

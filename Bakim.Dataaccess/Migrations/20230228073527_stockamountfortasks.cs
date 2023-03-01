using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class stockamountfortasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockAmount",
                table: "Task_Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockAmount",
                table: "Task_Stock");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class degisiklik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalepModal");

            migrationBuilder.AddColumn<int>(
                name: "VarlikId",
                table: "Talepler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VarlikId",
                table: "Talepler");

            migrationBuilder.CreateTable(
                name: "TalepModal",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false),
                    TalepId = table.Column<int>(type: "int", nullable: false),
                    VarlikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

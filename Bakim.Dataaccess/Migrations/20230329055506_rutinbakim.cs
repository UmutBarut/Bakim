using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class rutinbakim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Miktar",
                table: "Talepler",
                type: "double",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Olcu",
                table: "Stocks",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RutinBakim",
                columns: table => new
                {
                    RutinBakimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RutinBakimAdi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aciklama = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PlanlanmaTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BakimTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BakimAraligi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CorporationId = table.Column<int>(type: "int", nullable: false),
                    Pasif = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GrupId = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinBakim", x => x.RutinBakimId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RutinBakim_Stock",
                columns: table => new
                {
                    RutinBakim_StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RutinBakimId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinBakim_Stock", x => x.RutinBakim_StockId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RutinBakimGrup",
                columns: table => new
                {
                    GrupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrupAdi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    CorporationId = table.Column<int>(type: "int", nullable: false),
                    Pasif = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinBakimGrup", x => x.GrupId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RutinBakimKategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KategoriAdi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorporationId = table.Column<int>(type: "int", nullable: false),
                    Pasif = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinBakimKategori", x => x.KategoriId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RutinBakim");

            migrationBuilder.DropTable(
                name: "RutinBakim_Stock");

            migrationBuilder.DropTable(
                name: "RutinBakimGrup");

            migrationBuilder.DropTable(
                name: "RutinBakimKategori");

            migrationBuilder.AlterColumn<int>(
                name: "Miktar",
                table: "Talepler",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Olcu",
                keyValue: null,
                column: "Olcu",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Olcu",
                table: "Stocks",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

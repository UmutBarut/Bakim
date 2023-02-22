using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class pasif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "VarlikGroups",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "varlik",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "tedarikciFirmalar",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApproveDate",
                table: "Talepler",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "StokKategorisi",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "Stocks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "StockGroups",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "ProductionSections",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "DetayGrubu",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasif",
                table: "Birimler",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "VarlikGroups");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "varlik");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "tedarikciFirmalar");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "StokKategorisi");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "StockGroups");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "ProductionSections");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "DetayGrubu");

            migrationBuilder.DropColumn(
                name: "Pasif",
                table: "Birimler");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApproveDate",
                table: "Talepler",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}

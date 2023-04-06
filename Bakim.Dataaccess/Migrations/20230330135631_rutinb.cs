using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakim.Dataaccess.Migrations
{
    public partial class rutinb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "GrupId",
                table: "RutinBakimKategori");

            migrationBuilder.DropColumn(
                name: "GrupId",
                table: "RutinBakim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupId",
                table: "RutinBakimKategori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrupId",
                table: "RutinBakim",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

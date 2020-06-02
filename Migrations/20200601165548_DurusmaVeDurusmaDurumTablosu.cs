using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class DurusmaVeDurusmaDurumTablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Durusma",
                columns: table => new
                {
                    DurusmaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaId = table.Column<int>(nullable: false),
                    DurusmaTuruId = table.Column<int>(type: "int", nullable: false),
                    DurusmaAdi = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    MahkemeAciklama = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DurusmaTarihi = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durusma", x => x.DurusmaId);
                });

            migrationBuilder.CreateTable(
                name: "DurusmaDurum",
                columns: table => new
                {
                    DurusmaDurumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurusmaDurumu = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurusmaDurum", x => x.DurusmaDurumId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Durusma");

            migrationBuilder.DropTable(
                name: "DurusmaDurum");
        }
    }
}

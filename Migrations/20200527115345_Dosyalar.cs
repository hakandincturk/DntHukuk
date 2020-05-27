using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class Dosyalar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Dosyalar",
                columns: table => new
                {
                    DosyaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SorumluAvukatId = table.Column<Guid>(nullable: false),
                    MuvekkilId = table.Column<Guid>(nullable: false),
                    MuvekkilKonumuId = table.Column<int>(type: "int", nullable: false),
                    DosyaDurumuId = table.Column<int>(type: "int", nullable: false),
                    DosyaBaslamaTarihi = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DosyaBitisTarihi = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DosyaAdi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DosyaSehir = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DosyaIlce = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DosyaMahkemeAdi = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DosyaSiraNo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DosyaKonu = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DosyaSonDurum = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DosyaMuvekkilEvraklariPath = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DosyaKarsiTarafEvraklariPath = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DosyaMerciEvraklari = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DosyaKarsiTarafId = table.Column<int>(type: "int", nullable: false),
                    DosyaKarsiTarafBilgi = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DosyaTuru = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyalar", x => x.DosyaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

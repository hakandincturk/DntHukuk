using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class muvekkil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muvekkil",
                columns: table => new
                {
                    muvekkilId = table.Column<Guid>(nullable: false),
                    muvekkilAdi = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    muvekkilSoyAdi = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    muvekkilTc = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    muvekkilTuruId = table.Column<int>(type: "int", nullable: false),
                    muvekkilSorumluAvukat = table.Column<Guid>(nullable: false),
                    muvekkilEmaik = table.Column<string>(nullable: false),
                    muvekkilTelefon = table.Column<string>(type: "nvarchar(21)", nullable: true),
                    muvekkilAdres = table.Column<string>(type: "nvarchar(155)", nullable: true),
                    muvekkilAciklama = table.Column<string>(type: "nvarchar(155)", nullable: true),
                    muvekkilEvrakPath = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    muvekkilVergiDairesi = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    muvekkilVergiNo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    muvekkilYetkiliIsim = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muvekkil", x => x.muvekkilId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Muvekkil");
        }
    }
}

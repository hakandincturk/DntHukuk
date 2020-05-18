using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class CezaMahkemesiMuvekkilKonumu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CezaHukukuMuvekkilKonumu",
                columns: table => new
                {
                    cezaHukukuMuvekkilKonumuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cezaHukukuMuvekkilKonumuTuru = table.Column<string>(type: "nvarchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CezaHukukuMuvekkilKonumu", x => x.cezaHukukuMuvekkilKonumuId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CezaHukukuMuvekkilKonumu");
        }
    }
}

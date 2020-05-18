using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class IdareMahkemesiMuvekkilKonumu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdareMahkemesiMuvekkilKonumu",
                columns: table => new
                {
                    idareMahkemesiMuvekkilKonumuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idareMahkemesiMuvekkilKonumuTuru = table.Column<string>(type: "nvarchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdareMahkemesiMuvekkilKonumu", x => x.idareMahkemesiMuvekkilKonumuId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdareMahkemesiMuvekkilKonumu");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class IdareMahkemesiMahkemeTuru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdareMahkemesiMahkemeTuru",
                columns: table => new
                {
                    idareMahkemesiMahkemeTuruId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idareMahkemesiMahkemeTuruu = table.Column<string>(type: "nvarchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdareMahkemesiMahkemeTuru", x => x.idareMahkemesiMahkemeTuruId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdareMahkemesiMahkemeTuru");
        }
    }
}

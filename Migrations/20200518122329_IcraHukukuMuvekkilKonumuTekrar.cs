using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class IcraHukukuMuvekkilKonumuTekrar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcraHukukuMuvekkilKonumu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcraHukukMuvekkilKonumu = table.Column<string>(type: "nvarchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcraHukukuMuvekkilKonumu", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcraHukukuMuvekkilKonumu");
        }
    }
}

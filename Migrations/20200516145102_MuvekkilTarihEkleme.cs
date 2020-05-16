using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DntHukuk.Web.Migrations
{
    public partial class MuvekkilTarihEkleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "muvekkilUyelikTarihi",
                table: "Muvekkil",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "muvekkilUyelikTarihi",
                table: "Muvekkil");
        }
    }
}

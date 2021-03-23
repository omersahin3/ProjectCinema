using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCinema.Migrations
{
    public partial class duzeltme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChairID",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChairID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

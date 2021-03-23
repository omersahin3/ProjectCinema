using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCinema.Migrations
{
    public partial class hatali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChairID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChairID",
                table: "Tickets");
        }
    }
}

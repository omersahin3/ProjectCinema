using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCinema.Migrations
{
    public partial class change6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChairID",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ChairID",
                table: "Tickets",
                column: "ChairID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Chairs_ChairID",
                table: "Tickets",
                column: "ChairID",
                principalTable: "Chairs",
                principalColumn: "ChairID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Chairs_ChairID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ChairID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ChairID",
                table: "Tickets");
        }
    }
}

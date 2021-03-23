using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCinema.Migrations
{
    public partial class chair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chairs",
                columns: table => new
                {
                    ChairID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SaloonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chairs", x => x.ChairID);
                    table.ForeignKey(
                        name: "FK_Chairs_Saloons_SaloonID",
                        column: x => x.SaloonID,
                        principalTable: "Saloons",
                        principalColumn: "SaloonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chairs_SaloonID",
                table: "Chairs",
                column: "SaloonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chairs");
        }
    }
}

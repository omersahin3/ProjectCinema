using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCinema.Migrations
{
    public partial class Change3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieCategory_MovieCategoryID",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "MovieCategoryID",
                table: "Sessions",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_MovieCategoryID",
                table: "Sessions",
                newName: "IX_Sessions_MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_MovieID",
                table: "Sessions",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_MovieID",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Sessions",
                newName: "MovieCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_MovieID",
                table: "Sessions",
                newName: "IX_Sessions_MovieCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieCategory_MovieCategoryID",
                table: "Sessions",
                column: "MovieCategoryID",
                principalTable: "MovieCategory",
                principalColumn: "MovieCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

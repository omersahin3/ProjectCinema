using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCinema.Migrations
{
    public partial class Change4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Saloons_SaloonID",
                table: "Chairs");

            migrationBuilder.AlterColumn<int>(
                name: "SaloonID",
                table: "Chairs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Saloons_SaloonID",
                table: "Chairs",
                column: "SaloonID",
                principalTable: "Saloons",
                principalColumn: "SaloonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Saloons_SaloonID",
                table: "Chairs");

            migrationBuilder.AlterColumn<int>(
                name: "SaloonID",
                table: "Chairs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Saloons_SaloonID",
                table: "Chairs",
                column: "SaloonID",
                principalTable: "Saloons",
                principalColumn: "SaloonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceMS.Data.Migrations
{
    public partial class Makethenumberunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Number",
                table: "Cars",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_Number",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

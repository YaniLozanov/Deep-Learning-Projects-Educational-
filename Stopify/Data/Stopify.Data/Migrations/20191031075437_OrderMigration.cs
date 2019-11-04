using Microsoft.EntityFrameworkCore.Migrations;

namespace Stopify.Data.Migrations
{
    public partial class OrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IssuerId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IssuerId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IssuerId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "IssuerId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IssuerId",
                table: "Orders",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_IssuerId",
                table: "Orders",
                column: "IssuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IssuerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IssuerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IssuerId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuerId1",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IssuerId1",
                table: "Orders",
                column: "IssuerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId1",
                table: "Orders",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_IssuerId1",
                table: "Orders",
                column: "IssuerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId1",
                table: "Orders",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

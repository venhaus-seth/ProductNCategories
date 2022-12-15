using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductNCategories.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Categories_CategoryId1",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Products_ProductId1",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_CategoryId1",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_ProductId1",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Connections");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Connections",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Connections",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_CategoryId",
                table: "Connections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_ProductId",
                table: "Connections",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Categories_CategoryId",
                table: "Connections",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Products_ProductId",
                table: "Connections",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Categories_CategoryId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Products_ProductId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_CategoryId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_ProductId",
                table: "Connections");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Connections",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Connections",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Connections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Connections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connections_CategoryId1",
                table: "Connections",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_ProductId1",
                table: "Connections",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Categories_CategoryId1",
                table: "Connections",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Products_ProductId1",
                table: "Connections",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}

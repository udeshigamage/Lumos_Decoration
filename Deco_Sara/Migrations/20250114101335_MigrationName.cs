using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Customer_ID1",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_ID1",
                table: "Order",
                column: "Customer_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_Customer_ID1",
                table: "Order",
                column: "Customer_ID1",
                principalTable: "Customer",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_Customer_ID1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_Customer_ID1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Customer_ID1",
                table: "Order");
        }
    }
}

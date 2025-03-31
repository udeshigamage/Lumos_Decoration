using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class eruiop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_Customer_ID",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_ID",
                table: "Order",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_Customer_ID",
                table: "Order",
                column: "Customer_ID",
                principalTable: "Customer",
                principalColumn: "Customer_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Tb_Users_User_ID",
                table: "Order",
                column: "User_ID",
                principalTable: "Tb_Users",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_Customer_ID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Tb_Users_User_ID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_User_ID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_Customer_ID",
                table: "Order",
                column: "Customer_ID",
                principalTable: "Customer",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

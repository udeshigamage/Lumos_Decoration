using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdColumnToOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_ID1",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_ID",
                table: "Order",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_ID1",
                table: "Order",
                column: "User_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Tb_Users_User_ID",
                table: "Order",
                column: "User_ID",
                principalTable: "Tb_Users",
                principalColumn: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Tb_Users_User_ID1",
                table: "Order",
                column: "User_ID1",
                principalTable: "Tb_Users",
                principalColumn: "User_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Tb_Users_User_ID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Tb_Users_User_ID1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_User_ID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_User_ID1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "User_ID1",
                table: "Order");
        }
    }
}

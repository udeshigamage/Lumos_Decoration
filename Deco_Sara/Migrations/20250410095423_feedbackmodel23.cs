using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class feedbackmodel23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Customer_ID",
                table: "Feedbacks",
                column: "Customer_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Tb_Users_Customer_ID",
                table: "Feedbacks",
                column: "Customer_ID",
                principalTable: "Tb_Users",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Tb_Users_Customer_ID",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Customer_ID",
                table: "Feedbacks");
        }
    }
}

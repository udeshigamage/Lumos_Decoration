using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class er : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Category_Id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_Category_Id",
                table: "Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Tb_category");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Tb_Users",
                newName: "Role");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_time",
                table: "Tb_category",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified_time",
                table: "Tb_category",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_category",
                table: "Tb_category",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tb_category_Category_Id",
                table: "Products",
                column: "Category_Id",
                principalTable: "Tb_category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Tb_category_Category_Id",
                table: "Subcategories",
                column: "Category_Id",
                principalTable: "Tb_category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tb_category_Category_Id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Tb_category_Category_Id",
                table: "Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_category",
                table: "Tb_category");

            migrationBuilder.DropColumn(
                name: "Created_time",
                table: "Tb_category");

            migrationBuilder.DropColumn(
                name: "Modified_time",
                table: "Tb_category");

            migrationBuilder.RenameTable(
                name: "Tb_category",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Tb_Users",
                newName: "role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Category_Id",
                table: "Products",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_Category_Id",
                table: "Subcategories",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

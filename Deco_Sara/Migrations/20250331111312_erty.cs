using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class erty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NIC",
                table: "Tb_Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Tb_Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Servicerole",
                table: "Tb_Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "userimage",
                table: "Tb_Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIC",
                table: "Tb_Users");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Tb_Users");

            migrationBuilder.DropColumn(
                name: "Servicerole",
                table: "Tb_Users");

            migrationBuilder.DropColumn(
                name: "userimage",
                table: "Tb_Users");
        }
    }
}

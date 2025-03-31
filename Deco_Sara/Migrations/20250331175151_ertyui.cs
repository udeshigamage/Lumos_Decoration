using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class ertyui : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nic",
                table: "Employee",
                newName: "Nic");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employee",
                newName: "Email");

            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "Tb_Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isactive",
                table: "Tb_Users");

            migrationBuilder.RenameColumn(
                name: "Nic",
                table: "Employee",
                newName: "nic");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employee",
                newName: "email");
        }
    }
}

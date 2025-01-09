using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deco_Sara.Migrations
{
    /// <inheritdoc />
    public partial class Addtablejj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_Employees_EmployeeEmp_ID",
                table: "Allowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Emp_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_Employee_EmployeeEmp_ID",
                table: "Allowances",
                column: "EmployeeEmp_ID",
                principalTable: "Employee",
                principalColumn: "Emp_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_Employee_EmployeeEmp_ID",
                table: "Allowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Emp_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_Employees_EmployeeEmp_ID",
                table: "Allowances",
                column: "EmployeeEmp_ID",
                principalTable: "Employees",
                principalColumn: "Emp_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

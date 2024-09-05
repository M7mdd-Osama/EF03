using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    public partial class EmployeeDepartmentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentsDeptId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentsDeptId",
                table: "Employees",
                column: "DepartmentsDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentsDeptId",
                table: "Employees",
                column: "DepartmentsDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentsDeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentsDeptId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentsDeptId",
                table: "Employees");
        }
    }
}

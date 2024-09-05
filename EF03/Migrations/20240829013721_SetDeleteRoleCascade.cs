using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    public partial class SetDeleteRoleCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentsDeptId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsDeptId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentsDeptId",
                table: "Employees",
                column: "DepartmentsDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentsDeptId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsDeptId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentsDeptId",
                table: "Employees",
                column: "DepartmentsDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");
        }
    }
}

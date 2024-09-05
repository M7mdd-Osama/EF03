using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    public partial class RunSqlScriptForCreatingView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create View EmployeeDepartmentView
                                    with encryption
                                    as
                                    	select E.EmpId EmployeeId , E.Name EmployeeName , D.DeptId DepartmentId , D.DepartmentName 
                                    	from Departments D , Employees E
                                    	where D.DeptId = E.DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop View EmployeeDepartmentView");
        }
    }
}

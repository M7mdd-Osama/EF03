using Demo.Contexts;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Demo02
            //EnterpriseDbContext dbContext = new EnterpriseDbContext();
            //dbContext.Database.Migrate();

            //try
            //{
            //CRUD
            //}
            //finally
            //{
            //    dbContext.Dispose();
            //}

            //using (EnterpriseDbContext dbContext = new EnterpriseDbContext())
            //{
            //    //CRUD
            //}

            //using EnterpriseDbContext dbContext = new EnterpriseDbContext();
            //Employee Emp01 = new Employee()
            //{
            //    Name = "Mohamed",
            //    Salary = 4_000,
            //    Age = 25,
            //    Email = "Mohamed@gmail.com",
            //    Password = "password",
            //    Phonenumber = "12343424"
            //};
            //Employee Emp02 = new Employee()
            //{
            //    Name = "Ali",
            //    Salary = 5_000,
            //    Age = 26,
            //    Email = "Ali@gmail.com",
            //    Password = "password2",
            //    Phonenumber = "12343424"

            //};
            //Console.WriteLine(Emp01.EmpId);
            //Console.WriteLine(Emp02.EmpId);

            #region CRUD Operations
            #region Insert
            //Console.WriteLine(dbContext.Entry(Emp01).State);
            //Console.WriteLine(dbContext.Entry(Emp02).State);

            //dbContext.Employees.Add(Emp01);
            //dbContext.Employees.Add(Emp02);
            ////dbContext.Set<Employee>().Add(Emp02);
            ////dbContext.Add(Emp01);
            ////dbContext.Entry(Emp02).State = EntityState.Added;

            //Console.WriteLine(dbContext.Entry(Emp01).State);
            //Console.WriteLine(dbContext.Entry(Emp02).State);
            //dbContext.SaveChanges();
            //Console.WriteLine(dbContext.Entry(Emp01).State);
            //Console.WriteLine(dbContext.Entry(Emp02).State);
            #endregion

            #region Retrieve [Read]
            //var Employee = (from E in dbContext.Employees
            //               where E.EmpId == 3
            //               select E).FirstOrDefault();

            //Console.WriteLine(Employee?.Name ?? "NAN");
            #endregion

            #region Update
            //var Employee = (from E in dbContext.Employees
            //                where E.EmpId == 2
            //                select E).FirstOrDefault();

            //Employee.Phonenumber = "2343244";
            //Console.WriteLine(dbContext.Entry(Employee).State);
            //dbContext.SaveChanges();
            //Console.WriteLine(dbContext.Entry(Employee).State); 
            #endregion

            #region Delete - Remove
            //var Employee = (from E in dbContext.Employees
            //                where E.EmpId == 2
            //                select E).FirstOrDefault();
            //Console.WriteLine(dbContext.Entry(Employee).State);
            //dbContext.Employees.Remove(Employee);
            //Console.WriteLine(dbContext.Entry(Employee).State);
            //dbContext.SaveChanges();
            #endregion
            #endregion

            #endregion

            #region Explicit Loading
            //using EnterpriseDbContext DbContext = new EnterpriseDbContext();

            //var Employee = (from E in DbContext.Employees
            //                where E.EmpId == 5
            //                select E).FirstOrDefault();
            //DbContext.Entry(Employee).Reference(E => E.Department).Load();

            //Console.WriteLine($"{Employee?.Name ?? "Not Found"} :: {Employee?.Department?.Name ?? "NAN"}"); 
            #endregion

            #region Eager Loading
            //using EnterpriseDbContext DbContext = new EnterpriseDbContext();

            //var Employee = (from E in DbContext.Employees.Include(E => E.Department)
            //                where E.EmpId == 5
            //                select E).FirstOrDefault();

            //Console.WriteLine($"{Employee?.Name ?? "Not Found"} :: {Employee?.Department?.Name ?? "NAN"}");

            #endregion

            #region Lazy Loading
            //using EnterpriseDbContext DbContext = new EnterpriseDbContext();

            //var Employee = (from E in DbContext.Employees
            //                where E.EmpId == 5
            //                select E).FirstOrDefault();

            //Console.WriteLine($"{Employee?.Name ?? "Not Found"} :: {Employee?.Department?.Name ?? "NAN"}");
            #endregion

            #region Join

            //using EnterpriseDbContext DbContext = new EnterpriseDbContext();

            #region Query Syntax
            //var Result = from E in DbContext.Employees
            //             join D in DbContext.Departments
            //             on E.DepartmentId equals D.DeptId
            //             where E.Salary > 5000
            //             select new
            //             {
            //                  EmpName = E.Name,
            //                  DeptName = D.Name
            //             };
            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Fluent Syntax
            //var Result = DbContext.Employees.Join(DbContext.Departments, E => E.DepartmentId, D => D.DeptId, (E, D) => new
            //{
            //    EmpName = E.Name,
            //    DeptName = D.Name,
            //    E.Salary
            //}).Where(E => E.Salary < 5000);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #endregion

            #region View
            //using EnterpriseDbContext DbContext = new EnterpriseDbContext();

            //var Result = DbContext.Employees.FromSqlRaw(" select * from EmployeeDepartmentView ");

            //foreach (var item in DbContext.EmployeeDepartmentView)
            //{
            //    Console.WriteLine($"{item.EmployeeName} :: {item.DepartmentName}");
            //}
            #endregion

            #region Tracking , No Tracking
            //using EnterpriseDbContext DbContext = new EnterpriseDbContext();

            //DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            #region Tracking
            //var Result = (from E in DbContext.Employees
            //              where E.EmpId == 2
            //              select E).FirstOrDefault();

            //Console.WriteLine(DbContext.Entry(Result).State);
            //Result.Name = "Hmada";
            //Console.WriteLine(DbContext.Entry(Result).State);
            #endregion

            #region No Tracking
            //var Result02 = (from E in DbContext.Employees
            //              where E.EmpId == 2
            //              select E).AsNoTracking().FirstOrDefault();

            //Console.WriteLine(DbContext.Entry(Result02).State);
            //Result.Name = "Hmada";
            //Console.WriteLine(DbContext.Entry(Result02).State); 
            #endregion


            #endregion

            #region MaxBy() - MinBy()
            //Employee[] employees =
            //{
            //    new Employee () {EmpId = 1 ,Name = "Mohamed" , Age = 21 , Salary = 4_000 , Email = "Mohamed@gmail.com" , Phonenumber ="878342" , Password = "838264" },
            //    new Employee () {EmpId = 2 ,Name = "Osama" , Age = 25 , Salary = 6_000 , Email = "Osama@gmail.com" , Phonenumber ="4534534" , Password = "838264" }
            //};
            ////var MaxEmp = employees.Max();
            ////var MinEmp = employees.Min();

            ////MaxEmp = employees.OrderByDescending(E => E.Salary).FirstOrDefault();
            ////MinEmp = employees.OrderBy(E => E.Salary).FirstOrDefault();

            //var MaxEmp = employees.MaxBy(E => E.Salary);
            //var MinEmp = employees.MinBy(E => E.Salary);


            //Console.WriteLine(MaxEmp.Name);
            //Console.WriteLine(MinEmp.Name);
            #endregion



        }
    }
}

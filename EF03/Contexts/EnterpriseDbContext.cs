using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Configurations;

namespace Demo.Contexts
{
    internal class EnterpriseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = . ; Database = Enterprise; Trusted_Connection = true ; trustServerCertificate = true", X => X.UseDateOnlyTimeOnly());
        //optionsBuilder.UseSqlServer("Data source = . ; Initial Catalog = Enterprise; Integrated Security = true "); //Old

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EmployeeDepartmentView> EmployeeDepartmentView { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///modelBuilder.Entity<Department>()
            ///            .HasKey(D => D.DeptId);             
            ///modelBuilder.Entity<Department>()
            ///            .Property(D => D.DeptId)
            ///            .UseIdentityColumn(10, 10);             
            ///modelBuilder.Entity<Department>()
            ///            .Property(D => D.Name)
            ///            .HasColumnName("DepartmentName")
            ///            .HasColumnType("varchar")
            ///            .HasMaxLength(50)
            ///            .HasDefaultValue("Test")
            ///            .IsRequired(false);
            ///.HasAnnotation("", "");             
            ///modelBuilder.Entity<Department>()
            ///            .Property(D => D.DateOfCreation)
            ///            //.HasDefaultValue(DateTime.Now);
            ///            .HasDefaultValueSql("GETDATE()");

            ///modelBuilder.Entity<Department>(E =>
            ///{
            ///    E.HasKey(D => D.DeptId);             
            ///    E.Property(D => D.DeptId)
            ///     .UseIdentityColumn(10, 10);             
            ///    E.Property(D => D.Name)
            ///     .HasColumnName("DepartmentName")
            ///     .HasColumnType("varchar")
            ///     .HasMaxLength(50)
            ///     .HasDefaultValue("Test")
            ///     .IsRequired(false);
            ///    //.HasAnnotation("", "");             
            ///    E.Property(D => D.DateOfCreation)
            ///     //.HasDefaultValue(DateTime.Now);
            ///     .HasDefaultValueSql("GETDATE()");
            ///});

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            modelBuilder.Entity<Department>()
                        .HasMany(D => D.Employees)
                        .WithOne(E => E.Department)
                        .HasForeignKey(E => E.DepartmentId)
                        .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Student>()
            //            .HasMany(S => S.Courses)
            //            .WithMany(C => C.Students);


            //modelBuilder.Entity<Employee>()
            //            .HasOne(E => E.Department)
            //            .WithMany(D => D.Employees)
            //            .HasForeignKey(E => E.DepartmentsDeptId)
            //            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourse>()
                        .HasKey(SC => new { SC.StudentId, SC.CourseId });

            modelBuilder.Entity<Student>()
                        .HasMany(S => S.StudentCourses)
                        .WithOne(SC => SC.Student)
                        .IsRequired(true)
                        .HasForeignKey(S => S.StudentId);

            modelBuilder.Entity<Course>()
                        .HasMany(C => C.CourseStudents)
                        .WithOne(SC => SC.Course);

            modelBuilder.Entity<Department>()
                        .Property(D => D.DateOfCreation)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<EmployeeDepartmentView>().ToView("EmployeeDepartmentView").HasNoKey();


            base.OnModelCreating(modelBuilder);
        }
    }
}

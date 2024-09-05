using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entities
{
    //Entity, Domain Model, Model
    //POCO


    #region By Convention
    //internal class Employee
    //{
    //    public int Id { get; set; }
    //    public string? EmpName { get; set; }
    //    public decimal Salary { get; set; }
    //    public int? Age { get; set; }
    //}
    #endregion

    public class Employee : IComparable<Employee>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        //[MaxLength(50)]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }
        //[Column(TypeName = "Money")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Range(22, 45)]
        public int? Age { get; set; }
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        //[DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phonenumber { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }

        public int CompareTo(Employee? other)
            => this.Salary.CompareTo(other?.Salary);
    }
}

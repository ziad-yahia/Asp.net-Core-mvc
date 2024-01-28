using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Employee Id")]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(5)]
        [Column(TypeName ="varchar(5)")]
        [Display(Name ="Employee No.")]
        public string EmployeeNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName ="Varchar(150)")]
        [Display(Name ="Employee Name")]
        [Remote(action:"nameexist",controller: "Employee",AdditionalFields = "EmployeeId")]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date OF Birth  ")]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        [Required]
        [Column(TypeName ="decimal(12,2)")]
        [Display(Name ="Gross Salary")]
        public decimal GrossSalary { get; set;}

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Net Salary")]
        [customvalidation]
        public decimal NetSalary { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Display(Name="Department Name")]
        [NotMapped]
        public string DepatmentName { get; set; }

        public virtual   Department Department { get; set; }



    }
}

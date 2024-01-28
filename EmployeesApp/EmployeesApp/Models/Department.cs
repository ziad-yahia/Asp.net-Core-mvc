using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Display(Name ="Department Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        [Column(TypeName="varchar(150)")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        [Display(Name = "Department Abbreviation")]
        public int DepartmentAbbr { get; set; }

    }
}

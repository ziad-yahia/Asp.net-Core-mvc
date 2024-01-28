using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Models
{
    public class customvalidation:ValidationAttribute
    {
        HRDatabaseContext db = new HRDatabaseContext();
       
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            Employee employee = validationContext.ObjectInstance as Employee;


            int netsalary = int.Parse(value.ToString());
            if (netsalary < 10000) 
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("your netsalary is bigger than range ");
        }
    }
}

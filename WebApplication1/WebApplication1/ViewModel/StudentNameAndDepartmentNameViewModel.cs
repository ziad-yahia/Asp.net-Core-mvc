using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewModel
{
    //[ModelMetadataType(typeof(StudentNameAndDepartmentNameViewModel))]

    public class StudentNameAndDepartmentNameViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string DepartmentName { get; set; }
    }
}

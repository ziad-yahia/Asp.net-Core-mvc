using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentRepositry
    {
        List<Student> AllStudent();
        int Create(Student student);
        int Delete(int id);
        Student Onestudent(int id);
        int Update(Student student);
    }
}
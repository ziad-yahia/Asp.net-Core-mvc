using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentRepositry : IStudentRepositry
    {
        ITIEntities ITIEntities;
        public StudentRepositry(ITIEntities _ITIEntities)
        {
            ITIEntities = _ITIEntities;
        }

        public List<Student> AllStudent()
        {

            return ITIEntities.Student.ToList();
        }

        public Student Onestudent(int id)
        {
            return ITIEntities.Student.FirstOrDefault(s => s.id == id);
        }

        public int Create(Student student)
        {

            ITIEntities.Student.Add(student);

            return ITIEntities.SaveChanges();
        }

        public int Update(Student student)
        {

            ITIEntities.Student.Update(student);

            return ITIEntities.SaveChanges();
        }

        public int Delete(int id)
        {

            Student std = ITIEntities.Student.FirstOrDefault(s => s.id == id);
            ITIEntities.Student.Remove(std);
            return ITIEntities.SaveChanges();

        }
    }
}

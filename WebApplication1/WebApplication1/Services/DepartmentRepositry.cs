using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DepartmentRepositry :IDepartmentRepositry 
    {
    public readonly ITIEntities  ITIEntities ;

        public DepartmentRepositry(ITIEntities _ITIEntities)
        {
            ITIEntities= _ITIEntities;
        }
        public List<Department> GetAll()
        {

            return ITIEntities.Department.ToList();

        }

        public Department GetOne(int Id)
        {

            return ITIEntities.Department.Find(Id);
        }


        public int Create(Department department)
        {
            ITIEntities.Department.Add(department);

            return ITIEntities.SaveChanges();
        }

        public int Update(int Id, Department department)
        {
            Department department1 = ITIEntities.Department.Find(Id);
            department1.Name = department.Name;
            department1.MangerName = department.MangerName;
            ITIEntities.Department.Update(department1);
            return ITIEntities.SaveChanges();
        }

        public int Delete(int Id)
        {
            Department department = ITIEntities.Department.Find(Id);
            ITIEntities.Department.Remove(department);
            return ITIEntities.SaveChanges();
        }
    }
}

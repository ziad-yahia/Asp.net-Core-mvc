using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDepartmentRepositry
    {
        int Create(Department department);
        int Delete(int Id);
        List<Department> GetAll();
        Department GetOne(int Id);
        int Update(int Id, Department department);
    }
}
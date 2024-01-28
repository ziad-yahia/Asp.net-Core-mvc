using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Models
{
    public class HRDatabaseContext:DbContext
    {
        public HRDatabaseContext() : base()
        {

        }

        
       public DbSet<Employee> Employees { get; set;}
        public DbSet<Department> departments { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DESKTOP-U2G078Q\\SQLEXPRESS;Integrated Security=True;initial catalog=EmployeesDb"));
        }
    }
}

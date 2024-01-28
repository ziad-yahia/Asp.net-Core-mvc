using Microsoft.EntityFrameworkCore;

namespace Expenses.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)    
        {
            
        }

        public DbSet<ExpensesModel> Expenses { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DESKTOP-U2G078Q\\SQLEXPRESS;Integrated Security=True;database=ExpensesDb;"));
        }*/
    }
}


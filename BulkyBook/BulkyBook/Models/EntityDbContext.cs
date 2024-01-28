using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Models
{
    public class EntityDbContext:DbContext
    {
      

        public DbSet<Category> categories { get; set; }
        public DbSet<useridentity> useridentities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DESKTOP-U2G078Q\\SQLEXPRESS;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Database=Bulky;Multi Subnet Failover=False"));
        }
    }
}

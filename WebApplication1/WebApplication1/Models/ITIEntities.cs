using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication1.Models
{
    public class ITIEntities:IdentityDbContext
    {
        public ITIEntities()
        {
            
        }
        public ITIEntities(DbContextOptions<ITIEntities> options):base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // initial Catalog=ITIFirstEntity  to give name to database 
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DESKTOP-U2G078Q\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;initial Catalog=ITIFirstEntity;Multi Subnet Failover=False"));

        }
    }
}

//base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DESKTOP-J4CBOSK\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;initial Catalog=ITIFirstEntity;Multi Subnet Failover=False"));


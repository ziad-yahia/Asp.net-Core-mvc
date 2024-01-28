using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string MangerName { get; set; }
    }
}
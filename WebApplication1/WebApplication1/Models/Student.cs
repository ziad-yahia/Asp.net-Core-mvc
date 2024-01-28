using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   
    public class Student
    {
        internal int id;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int Dept { get; set;}

        public Department Department { get; set; }

    }
}

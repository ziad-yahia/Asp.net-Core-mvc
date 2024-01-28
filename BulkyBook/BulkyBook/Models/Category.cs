using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Display Order")]
        [Range(1,100,ErrorMessage ="Display Order Must Be Between 1 and 100 only!")]
        public int Displayorder { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}

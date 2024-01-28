using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}

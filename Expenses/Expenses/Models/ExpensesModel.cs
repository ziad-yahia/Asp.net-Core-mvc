using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class ExpensesModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal MoneySpent { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

        [Required]
        public string Category { get; set; }
    }
}

using Expenses.Models;
using Expenses.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository expensesRepository;

        public ExpensesController(IExpensesRepository _expensesRepository) {
            expensesRepository = _expensesRepository;
        }
        public IActionResult Index(string searching)
        {
            List<ExpensesModel> list = new List<ExpensesModel>();

            if (string.IsNullOrEmpty(searching))
            {
                list = expensesRepository.GetExpensesList();
            }
            else 
            { 
                list= expensesRepository.Search(searching);
            }

            return View(list);
        }
    }
}

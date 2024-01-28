using Expenses.Models;

namespace Expenses.Services
{
    public interface IExpensesRepository
    {
        int Create(ExpensesModel expenses);
        int Delete(int id);
        ExpensesModel GetExpensesById(int id);
        List<ExpensesModel> GetExpensesList();
        List<ExpensesModel> Search(string searchstring);
        int Update(ExpensesModel expenses);
    }
}
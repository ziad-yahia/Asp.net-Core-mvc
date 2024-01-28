using Expenses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Expenses.Services
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExpensesRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

       /* public List<ExpensesModel> GetExpensesList()
        {
            return dbContext.Expenses.ToList();
        }*/

        public ExpensesModel GetExpensesById(int id)
        {
            return dbContext.Expenses.FirstOrDefault(x => x.Id == id);
        }

        public int Create(ExpensesModel expenses)
        {
            dbContext.Expenses.Add(expenses);
            return dbContext.SaveChanges(); ;
        }

        public int Update(ExpensesModel expenses)
        {
            dbContext.Expenses.Update(expenses);
            return dbContext.SaveChanges(); ;
        }

        public int Delete(int id)
        {
            ExpensesModel expenses = dbContext.Expenses.Find(id);
            dbContext.Expenses.Remove(expenses);
            return dbContext.SaveChanges();
        }

        public List<ExpensesModel> Search(string searchstring)
        {
            return dbContext.Expenses.Where(s=>s.Title== searchstring).ToList();
        }
    }
}

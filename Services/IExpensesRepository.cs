using ExpensesTrackingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Services
{
    public interface IExpensesRepository
    {
        IEnumerable<Expenses> GetAllUserExpenses(int UserId);
        // Expenses GetUserExpense(int ExpenseID);
        bool ExpenseExists(int Id);
        bool UserExists(int Id);
        Expenses GetSingleUserExpense(int UserId, int ExpenseId);
        void AddExpense(int userId, Expenses expense);
        public bool Save();
    }
}

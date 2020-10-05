using ExpensesTrackingSystem.API.DbContexts;
using ExpensesTrackingSystem.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Services
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ExpensesTrackingContext _context;

        public ExpensesRepository(ExpensesTrackingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Expenses> GetAllUserExpenses(int UserId)
        {

            return _context.Expenses
                       .Where(c => c.UserId == UserId)
                       .OrderBy(c => c.DateCreated).ToList();
        }


       public Expenses GetSingleUserExpense(int UserId, int ExpenseId)
        {
            return _context.Expenses
             .Where(c => c.UserId == UserId && c.Id == ExpenseId).FirstOrDefault();

        }
        public bool UserExists(int UserId)
        {
            if (UserId.Equals(null))
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            return _context.Users.Any(a => a.Id == UserId);
        }

        bool IExpensesRepository.ExpenseExists(int ExpenseId)
        {
            if (ExpenseId.Equals(null))
            {
                throw new ArgumentNullException(nameof(ExpenseId));
            }

            return _context.Expenses.Any(a => a.Id == ExpenseId);
        }

        public void AddExpense(int  userId, Expenses expense)
        {
            if (userId.Equals(null) )
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            expense.UserId = userId;
            _context.Expenses.Add(expense);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

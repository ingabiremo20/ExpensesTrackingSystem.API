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

        //public bool ExpenseExists(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Expenses> GetAllUserExpenses(int UserId)
        {

            return _context.Expenses
                       .Where(c => c.UserId == UserId)
                       .OrderBy(c => c.DateCreated).ToList();
        }

        //public Expenses GetUserExpense(int ExpenseID)
        //{
        //    throw new NotImplementedException();
        //}

       public Expenses GetSingleUserExpense(int UserId, int ExpenseId)
        {
            //return _context.Expenses
            //           .Where(c => c.Id == ExpenseId && c.UserId == UserId).FirstOrDefault();
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
    }
}

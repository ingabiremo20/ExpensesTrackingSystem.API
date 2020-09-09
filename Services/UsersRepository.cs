using ExpensesTrackingSystem.API.DbContexts;
using ExpensesTrackingSystem.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Services
{
    public class UsersRepository: IUsersRepository
    {
        private readonly ExpensesTrackingContext _context;

        public UsersRepository(ExpensesTrackingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public IEnumerable<Users> GetAllUsers()
        {
            return _context.Users.Include(c => c.Currencies).ToList<Users>();
        }

        public Users GetUser(int UserId)
        {
            return _context.Users.Include(c=>c.Currencies).FirstOrDefault(x => x.UserId == UserId);
        }
        public bool UserExists(int UserId)
        {
            if (UserId.Equals(null))
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            return _context.Users.Any(a => a.UserId == UserId);
        }
    }
}

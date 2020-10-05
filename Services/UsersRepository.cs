using ExpensesTrackingSystem.API.DbContexts;
using ExpensesTrackingSystem.API.Entities;
using ExpensesTrackingSystem.API.ResourceParameters;
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
        public IEnumerable<Users> GetAllUsers(UsersResourceParameters usersResourceParameters) 
          
        {
            if (usersResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(usersResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(usersResourceParameters.FilterUser) && string.IsNullOrWhiteSpace(usersResourceParameters.SearchUser))
            {
                return GetAllUsers();
            }

            var collection = _context.Users.Include(c => c.Currencies) as IQueryable<Users>;
            if (!string.IsNullOrWhiteSpace(usersResourceParameters.FilterUser))
            {
                var filterUser = usersResourceParameters.FilterUser.Trim();
                collection= collection.Where(a => a.UserName == filterUser);
            }
            if (!string.IsNullOrWhiteSpace(usersResourceParameters.SearchUser))
            {
                var searchUser = usersResourceParameters.SearchUser.Trim();
                collection = collection.Where(a => a.UserName.Contains(searchUser)
                || a.FirstName.Contains(searchUser) || a.LastName.Contains(searchUser));
            }
            return collection.ToList();
           
        }
        public Users GetUser(int UserId)
        {
            return _context.Users.Include(c=>c.Currencies).FirstOrDefault(x => x.Id == UserId);
        }
        public bool UserExists(int UserId)
        {
            if (UserId.Equals(null))
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            return _context.Users.Any(a => a.Id == UserId);
        }
        public void AddUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}

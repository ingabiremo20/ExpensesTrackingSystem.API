using ExpensesTrackingSystem.API.Entities;
using ExpensesTrackingSystem.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Services
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();
        public IEnumerable<Users> GetAllUsers(UsersResourceParameters usersResourceParameters);
        Users GetUser(int UserId);
    }
}

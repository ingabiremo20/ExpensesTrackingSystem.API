using ExpensesTrackingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Services
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();
        Users GetUser(int UserId);
    }
}

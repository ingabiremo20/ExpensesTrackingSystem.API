using ExpensesTrackingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Models
{
    public class UsersDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }    
        public string Name { get; set; }     
        public int Age { get; set; }
        public Currency Currencies { get; set; }

    }
}

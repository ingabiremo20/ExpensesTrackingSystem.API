using ExpensesTrackingSystem.API.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace ExpensesTrackingSystem.API.Models
{
    public class CreateUserDto
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
     
        public DateTimeOffset DateOfBirth { get; set; }       
        public int CurrencyId { get; set; }
       
    }
}

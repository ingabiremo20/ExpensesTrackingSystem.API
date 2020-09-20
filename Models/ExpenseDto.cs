using ExpensesTrackingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Models
{
    public class ExpenseDto
    {
        public int Id { get; set; }
       public int CategoryId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateSpent { get; set; }
        public int UserId { get; set; }
    }
}

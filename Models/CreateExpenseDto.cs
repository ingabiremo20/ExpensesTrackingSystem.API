using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Models
{
    public class CreateExpenseDto
    {
        public int CategoryId { get; set; }

        public decimal ExpenseAmount { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTime.UtcNow;
        public DateTimeOffset DateSpent { get; set; }
    }
}

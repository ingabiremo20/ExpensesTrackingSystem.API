using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Entities
{
    public class Expenses
    {
       [Key]
        public int ExpenseID { get; set; }

        [ForeignKey("UserId")]
        public Users Users { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
        
        public decimal ExpenseAmount { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateSpent{ get; set; }
    }
}

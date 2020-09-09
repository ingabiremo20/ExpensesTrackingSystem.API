using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Entities
{
    public class Periods
    {
        [Key]
        public int PeriodID { get; set; }
        public decimal Amount
        {
            get; set;
        }
    }
}

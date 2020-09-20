using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Entities
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }

        [ForeignKey("PeriodId")]
        public Periods Periods { get; set; }

    }
}

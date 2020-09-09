using ExpensesTrackingSystem.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackingSystem.API.DbContexts
{
    public class ExpensesTrackingContext : DbContext
    {
        public ExpensesTrackingContext()
        {

        }
        public ExpensesTrackingContext(DbContextOptions<ExpensesTrackingContext> options)
      : base(options)
        { }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<Expenses> Expenses { get; set; }

        public DbSet<Budget> Budget { get; set; }
        public DbSet<Periods> Periods { get; set; }
    }
}

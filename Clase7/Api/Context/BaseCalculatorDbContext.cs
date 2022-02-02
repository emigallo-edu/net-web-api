using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public abstract class BaseCalculatorDbContext : DbContext
    {
        protected BaseCalculatorDbContext(DbContextOptions<BaseCalculatorDbContext> options) : base(options)
        {
        }

        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<CalculatorHistoryModel> Histories { get; set; }
    }
}
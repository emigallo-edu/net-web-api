using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
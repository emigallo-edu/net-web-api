using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TestingClass> TestingClasses { get; set; }
        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ConfigClub();
            mb.ConfigPlayer();
            mb.ConfigMatch();
            mb.ConfigStadium();
            mb.ConfigTournament();
        }
    }
}
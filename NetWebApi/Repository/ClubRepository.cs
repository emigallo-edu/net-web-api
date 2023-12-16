using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    public class ClubRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ClubRepository(DbContextOptions<ApplicationDbContext> options)
        {
            this._options = options;
        }

        public async Task<List<Club>> GetAll()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Clubs
                    .Include(x=>x.Stadium)
                    .ToListAsync();
            }
        }
    }
}
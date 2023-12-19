using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entities;

namespace Repository
{
    public class ClubDbRepository : IClubRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ClubDbRepository(DbContextOptions<ApplicationDbContext> options)
        {
            this._options = options;
        }

        public async Task<List<Club>> GetAllAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Clubs
                    .Include(x => x.Stadium)
                    .ToListAsync();
            }
        }
    }
}
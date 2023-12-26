using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    public class StandingRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public StandingRepository(DbContextOptions<ApplicationDbContext> options)
        {
            this._options = options;
        }

        public async Task<Standing> GetAsync(int id, int clubId)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Standings
                    .FirstAsync(x => x.Id == id
                        && x.ClubId == clubId);
            }
        }

        public async Task<int> InsertStandingClubAsync(Standing item)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                context.Standings.Add(item);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateStandingClubAsync(Standing item)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                context.Standings.Update(item);
                return await context.SaveChangesAsync();
            }
        }
    }
}
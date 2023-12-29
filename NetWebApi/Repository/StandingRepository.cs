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

        public async Task<List<Standing>> GetAsync(int id)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Standings
                    .Include(x => x.Club)
                    .Where(x => x.TournamentId == id)
                    .ToListAsync();
            }
        }

        public async Task<Standing> GetAsync(int id, int clubId)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Standings
                    .FirstAsync(x => x.TournamentId == id
                        && x.ClubId == clubId);
            }
        }

        public async Task<int> InsertAsync(Standing item)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                context.Standings.Add(item);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> InsertAsync(ICollection<Standing> list)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                foreach (var item in list)
                {
                    context.Standings.Add(item);
                }
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateAsync(Standing item)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                context.Standings.Update(item);
                return await context.SaveChangesAsync();
            }
        }
    }
}
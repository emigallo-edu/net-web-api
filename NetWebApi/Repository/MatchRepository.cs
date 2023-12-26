using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    public class MatchRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public MatchRepository(DbContextOptions<ApplicationDbContext> options)
        {
            this._options = options;
        }

        public async Task<Match> GetAsync(int id)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Matches
                    .FirstAsync(x => x.Id == id);
            }
        }

        public async Task<List<Match>> GetByTournamentsync(int tournamentId)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Matches
                    .Where(x => x.TournamentId == tournamentId)
                    .ToListAsync();
            }
        }

        public async Task<int> InsertMatchResult(MatchResult item)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                context.MatchsResults.Add(item);
                return await context.SaveChangesAsync();
            }
        }
    }
}
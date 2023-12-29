using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    public class TournamentRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public TournamentRepository(DbContextOptions<ApplicationDbContext> options)
        {
            this._options = options;
        }

        public async Task<int> InsertAsync(Tournament item)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                await context.Tournaments.AddAsync(item);
                return await context.SaveChangesAsync();
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    public class ResponseAuditRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ResponseAuditRepository(DbContextOptions<ApplicationDbContext> options)
        {
            this._options = options;
        }

        public async Task<int> InsertAsync(ResponseAudit item)
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                context.ResponseAudits.Add(item);
                return await context.SaveChangesAsync();
            }
        }
    }
}
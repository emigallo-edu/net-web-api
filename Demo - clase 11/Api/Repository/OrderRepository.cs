using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class OrderRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public OrderRepository(DbContextOptions<ApplicationDbContext> options)
        {
            this._options = options;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                return await context.Orders
                    .ToListAsync();
            }
        }
    }
}
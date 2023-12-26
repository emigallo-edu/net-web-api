using Faker;
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

        public async Task<List<Club>> GetAllSelectingAddressAndCityAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                var result = from club in context.Clubs
                             select new Club
                             {
                                 Address = club.Address,
                                 City = club.City,
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<List<ShortClub>> GetAllShortAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                var result = from club in context.Clubs
                             select new ShortClub
                             {
                                 Address = club.Address,
                                 City = club.City,
                                 Phone = club.Phone
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<List<ShortClub>> GetAllShortAsyncC()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                var query = from club in context.Clubs
                            join stadium in context.Stadiums
                                on club.Id equals stadium.Capacity
                            select new
                            {
                                Address = club.Address,
                                City = club.City,
                                Phone = club.Phone,
                                Capacity = stadium.Capacity
                            };

                List<ShortClub> result = new List<ShortClub>();
                foreach (var item in query)
                {
                    result.Add(new ShortClub()
                    {
                        Address = item.Address,
                        City = item.City,
                        Phone = item.Phone
                    });
                }
                return result;
            }
        }
    }
}
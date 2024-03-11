using Model.Entities;

namespace Model
{
    public interface IClubRepository
    {
        Task<List<Club>> GetAllAsync();
        Task<List<ShortClub>> GetAllShortAsync();
        Task<int> InsertAsync(Club club);
        Task ChangeName(int cludId, string newName);
    }
}
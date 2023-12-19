using Model.Entities;

namespace Model
{
    public interface IClubRepository
    {
        Task<List<Club>> GetAllAsync();
    }
}
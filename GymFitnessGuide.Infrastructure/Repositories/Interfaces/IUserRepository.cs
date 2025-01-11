using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(User user);
    }
}

using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<bool> AddAsync(TestAnswer answer);
        Task<IEnumerable<TestAnswer>> GetAllAsync();
        Task<TestAnswer?> GetByIdAsync(int id);
        Task<IEnumerable<TestAnswer>> GetAnswersByUserIdAsync(int userId);
        Task<bool> UpdateAsync(TestAnswer answer);
        Task<bool> DeleteAsync(int id);
    }
}

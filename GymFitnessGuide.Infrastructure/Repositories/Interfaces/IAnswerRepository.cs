using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<TestAnswer>> GetAllAsync();
        Task<TestAnswer?> GetByIdAsync(int id);
        Task<IEnumerable<TestAnswer>> GetAnswersByUserIdAsync(int userId);
        Task<bool> AddAsync(TestAnswer answer);
        Task<bool> UpdateAsync(TestAnswer answer);
        Task<bool> DeleteAsync(int id);
    }
}

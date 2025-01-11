using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<bool> AddAsync(TestQuestion question);
        Task<IEnumerable<TestQuestion>> GetAllAsync();
        Task<TestQuestion?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TestQuestion question);
        Task<bool> DeleteAsync(int id);
    }
}

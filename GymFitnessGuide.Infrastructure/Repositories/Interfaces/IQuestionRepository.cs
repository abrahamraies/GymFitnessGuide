using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<TestQuestion>> GetAllAsync();
        Task<TestQuestion?> GetByIdAsync(int id);
        Task<IEnumerable<TestQuestion>> GetByCategoryIdAsync(int categoryId);
        Task<bool> AddAsync(TestQuestion question);
        Task<bool> UpdateAsync(TestQuestion question);
        Task<bool> DeleteAsync(int id);
    }
}

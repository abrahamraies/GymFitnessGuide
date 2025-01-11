using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> AddAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}

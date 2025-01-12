using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface IRecommendationRepository
    {
        Task<IEnumerable<Recommendation>> GetAllAsync();
        Task<IEnumerable<Recommendation>> GetByCategoryIdAsync(int categoryId);
        Task<Recommendation?> GetByIdAsync(int id);
        Task<bool> AddAsync(Recommendation recommendation);
        Task<bool> UpdateAsync(Recommendation recommendation);
        Task<bool> DeleteAsync(int id);
    }
}
